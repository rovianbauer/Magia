using Flunt.Notifications;
using Magia.Domain.AgendamentoContext.Entities;
using Magia.Infra.DataAccess.Entity.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Magia.Infra.DataAccess.Entity.DbContext
{
    public class AgendamentoDbContext
    {
        public AgendamentoDbContext()
        {
        }

        public DbSet<AgendamentoEntity> Agendamentos { get; set; }
        public DbSet<SalaEntity> Salas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new SalaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
