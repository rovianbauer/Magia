using Magia.Application.AgendamentoContext.Commands;
using Magia.Domain.Core.Commands;
using Magia.Infra.DataAccess.Entity.AgendamentoContext;
using Magia.WebAPI.Configuration;
using Magia.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Magia.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // IoC
            DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(BaseCommand));
            services.AddMediatR(typeof(NovoAgendamentoCommand));

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Entity Framework
            services.AddDbContext<AgendamentoDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("default")));

            // Controllers
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(TransactionalActionFilter));
                options.Filters.Add(typeof(ModelStateValidationFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
