using Magia.Application.AgendamentoContext.Commands;
using Magia.Domain.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Magia.WebAPI.Controllers
{
    [ApiController]
    [Route("salas")]
    public class SalaController : ApiController
    {
        public SalaController(IDomainNotificationHandler notification,
            IMediator mediator) : base(notification, mediator)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarCliente(NovaSalaCommand command)
        {
            return CustomResponse(await Mediator.Send(command));
        }


    }
}
