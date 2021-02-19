using AutoMapper;
using Magia.Application.AgendamentoContext.Queries;
using Magia.Application.AgendamentoContext.QueryResults;
using Magia.Domain.AgendamentoContext.Interfaces;
using Magia.Domain.Core.Notification;
using Magia.Domain.Core.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Application.AgendamentoContext.QueryHandlers
{
    public class ObterSalasQueryHandler
        : BaseQueryHandler, IRequestHandler<ObterSalasQuery, IEnumerable<ObterSalasQueryResult>>
    {
        private readonly ISalaRepository _salaRepository;

        public ObterSalasQueryHandler(IDomainNotificationHandler notification,
            IMapper mapper,
            ISalaRepository salaRepository)
            : base(notification, mapper)
        {
            _salaRepository = salaRepository;
        }

        public async Task<IEnumerable<ObterSalasQueryResult>> Handle(ObterSalasQuery request, CancellationToken cancellationToken)
        {
            var todasSalas = await _salaRepository.BuscarAsync(x => x.Id != null);

            return Mapper.Map<IEnumerable<ObterSalasQueryResult>>(todasSalas);
        }
    }
}
