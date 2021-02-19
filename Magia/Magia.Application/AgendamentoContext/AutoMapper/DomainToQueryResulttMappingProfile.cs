using AutoMapper;
using Magia.Application.AgendamentoContext.QueryResults;
using Magia.Domain.AgendamentoContext.Entities;

namespace Magia.Application.AgendamentoContext.AutoMapper
{
    public class DomainToQueryResulttMappingProfile : Profile
    {
        public DomainToQueryResulttMappingProfile()
        {
            CreateMap<SalaEntity, ObterSalasQueryResult>();
        }
    }
}
