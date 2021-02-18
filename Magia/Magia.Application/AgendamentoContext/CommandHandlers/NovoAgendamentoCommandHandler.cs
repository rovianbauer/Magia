using Magia.Application.Agendamento.Commands;
using Magia.Domain.Core.Commands;
using Magia.Domain.Core.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Application.Agendamento.CommandHandlers
{
    public class NovoAgendamentoCommandHandler :
        BaseCommandHandler, IRequestHandler<NovoAgendamentoCommand, bool>
    {
        public NovoAgendamentoCommandHandler(IMediator mediator,
            IDomainNotificationHandler notification) : base(mediator, notification)
        {
        }

        public async Task<bool> Handle(NovoAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var x = 1;


            return true;
        }
    }
}
