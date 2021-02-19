using Magia.Application.AgendamentoContext.Commands;
using Magia.Domain.AgendamentoContext.Interfaces;
using Magia.Domain.Core.Commands;
using Magia.Domain.Core.Notification;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Application.AgendamentoContext.CommandHandlers
{
    public class NovaSalaCommandHandler
        : BaseCommandHandler, IRequestHandler<NovaSalaCommand, bool>
    {
        private readonly ISalaRepository _salaRepository;

        public NovaSalaCommandHandler(IMediator mediator,
            IDomainNotificationHandler notification,
            ISalaRepository salaRepository)
            : base(mediator, notification)
        {
            _salaRepository = salaRepository;
        }

        public async Task<bool> Handle(NovaSalaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var novaSala =
                    new Domain.AgendamentoContext.Entities.SalaEntity(request.Descricao);

                if (novaSala.IsValid())
                    await _salaRepository.InsereAsync(novaSala);

                return novaSala.Valid;
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
