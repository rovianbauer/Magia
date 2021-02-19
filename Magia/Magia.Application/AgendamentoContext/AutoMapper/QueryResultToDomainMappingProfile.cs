using AutoMapper;
using Magia.Application.AgendamentoContext.QueryResults;
using Magia.Domain.AgendamentoContext.Entities;

namespace Magia.Application.AgendamentoContext.AutoMapper
{
    public class QueryResultToDomainMappingProfile : Profile
    {
        public QueryResultToDomainMappingProfile()
        {
            CreateMap<ObterSalasQueryResult, SalaEntity>();
        }
    }
}
