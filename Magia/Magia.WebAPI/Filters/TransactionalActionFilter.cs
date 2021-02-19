using Magia.Domain.Core.Notification;
using Magia.Domain.Core.UoW.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Magia.WebAPI.Filters
{
    public sealed class TransactionalActionFilter
        : ActionFilterAttribute
    {

        private IUnitOfWork _UoW;
        private IDomainNotificationHandler _notification;

        public TransactionalActionFilter(IUnitOfWork uoW, IDomainNotificationHandler notification)
        {
            _UoW = uoW;
            _notification = notification;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (!_notification.HasNotifications && actionExecutedContext.ModelState.IsValid && actionExecutedContext.Exception == null)
                _UoW.Commit();

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
