using Magia.Application.AgendamentoContext.Commands;
using Magia.Domain.AgendamentoContext.Entities;
using Magia.Domain.AgendamentoContext.Interfaces;
using Magia.Domain.Core.Commands;
using Magia.Domain.Core.Notification;
using MediatR;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Application.AgendamentoContext.CommandHandlers
{
    public class NovoAgendamentoCommandHandler :
        BaseCommandHandler, IRequestHandler<NovoAgendamentoCommand, bool>
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IAgendamentoRepository _agendamentoRepository;

        public NovoAgendamentoCommandHandler(IMediator mediator,
            IDomainNotificationHandler notification,
            ISalaRepository salaRepository,
            IAgendamentoRepository agendamentoRepository)
            : base(mediator, notification)
        {
            _salaRepository = salaRepository;
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<bool> Handle(NovoAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var salaAgendamento
                = await _salaRepository.ObtemPorIdAsync(request.SalaId);

            if (salaAgendamento == null || salaAgendamento.Deletado)
            {
                AddNotification("Sala não encontrada");
                return false;
            }

            var novoAgendamento = new AgendamentoEntity(salaAgendamento,
                request.Titulo,
                request.DataHoraInicio,
                request.DataHoraFim);

            if (novoAgendamento.IsValid())
            {
                var agendamentoEmConflito =
                    (await _agendamentoRepository.BuscarAsync(x => x.Sala.Id == request.SalaId
                                                                &&
                                                                ((x.DataHoraInicio <= request.DataHoraInicio && x.DataHoraFim >= request.DataHoraInicio)
                                                                 || (x.DataHoraInicio <= request.DataHoraFim && x.DataHoraFim >= request.DataHoraFim)
                                                                 || (x.DataHoraInicio >= request.DataHoraInicio && x.DataHoraFim <= request.DataHoraFim))
                                                              ));
                var cultura = new CultureInfo("pt-BR");

                if (!agendamentoEmConflito.Any())
                    await _agendamentoRepository.InsereAsync(novoAgendamento);
                else
                    AddNotification($"A Sala ({salaAgendamento.Descricao}) já possui um agendamento com " +
                                    $"inicio {agendamentoEmConflito.First().DataHoraInicio.ToString("F", cultura)} " +
                                    $"e fim {agendamentoEmConflito.First().DataHoraFim.ToString("F", cultura)}");
            }

            AddNotifications(novoAgendamento);

            return !Notification.HasNotifications;
        }
    }
}
