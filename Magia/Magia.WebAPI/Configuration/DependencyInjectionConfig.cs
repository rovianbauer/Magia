using Magia.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Magia.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            AgendamentoContextIoC.RegisterServices(services);
            AgendamentoContextIoC.RegisterRepository(services);
        }
    }
}
