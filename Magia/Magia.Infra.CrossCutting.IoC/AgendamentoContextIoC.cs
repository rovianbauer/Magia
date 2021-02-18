using Magia.Domain.Core.Commands;
using Magia.Domain.Core.Notification;
using Magia.Domain.Core.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Magia.Infra.CrossCutting.IoC
{
    public static class AgendamentoContextIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateQueryPipelineBehavior<,>));
        }
    }
}
