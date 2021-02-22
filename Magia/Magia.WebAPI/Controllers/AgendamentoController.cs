using Magia.Application.AgendamentoContext.Commands;
using Magia.Domain.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Magia.WebAPI.Controllers
{
    [ApiController]
    [Route("agendamentos")]
    public class AgendamentoController : ApiController
    {
        public AgendamentoController(IDomainNotificationHandler notification,
            IMediator mediator) : base(notification, mediator)
        { }

        /// <summary>
        /// Utilizar para cadastrar um novo Agendamento
        /// </summary> 
        [HttpPost("")]
        public async Task<IActionResult> NovoAgendamento(NovoAgendamentoCommand command)
        {
            return CustomResponse(await Mediator.Send(command));
        }

    }
}
