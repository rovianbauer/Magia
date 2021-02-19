using Magia.Application.AgendamentoContext.QueryResults;
using Magia.Domain.Core.Queries;
using MediatR;
using System.Collections.Generic;

namespace Magia.Application.AgendamentoContext.Queries
{
    public class ObterSalasQuery
        : BaseQuery, IRequest<IEnumerable<ObterSalasQueryResult>>
    {
        public override bool IsValid()
        {
            return Valid;
        }

        public override void Validate()
        {
        }
    }
}
