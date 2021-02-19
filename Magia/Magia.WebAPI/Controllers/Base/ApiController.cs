using Flunt.Notifications;
using Magia.Domain.Core.Notification;
using Magia.WebAPI.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magia.WebAPI.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();
        public IDomainNotificationHandler Notification;
        public IMediator Mediator;

        protected ApiController(IDomainNotificationHandler notification,
            IMediator mediator)
        {
            Notification = notification;
            Mediator = mediator;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            Validar();

            if (IsOperationValid())
            {
                if (result != null && result.GetType() == typeof(bool))
                    if ((bool)result)
                        return Ok();
                    else
                        return BadRequest(new ErrorResponse(_errors.ToList()));

                return Ok(result);
            }

            return NotFound(new ErrorResponse(_errors.ToList()));
        }

        protected ActionResult InternalServerError()
        {
            Validar();

            return StatusCode(500, new ErrorResponse(_errors.ToList()));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }


        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }

        private void Validar()
        {
            foreach (var error in Notification.GetNotifications())
            {
                AddError(error.Value);
            }
        }

        protected void AddNotification(string notification)
        {
            Notification.Add(notification);
        }

        protected void AddNotifications(Notifiable notifiable)
        {
            if (notifiable != null && notifiable.Invalid)
                foreach (var notify in notifiable.Notifications)
                    Notification.Add(notify.Property, notify.Message);
        }

    }
}

