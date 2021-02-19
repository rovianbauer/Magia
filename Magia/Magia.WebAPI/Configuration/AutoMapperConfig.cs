using Magia.Application.AgendamentoContext.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Magia.WebAPI.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToQueryResulttMappingProfile), typeof(QueryResultToDomainMappingProfile));
        }
    }
}
