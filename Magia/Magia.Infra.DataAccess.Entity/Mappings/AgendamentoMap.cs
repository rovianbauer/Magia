using Magia.Domain.AgendamentoContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magia.Infra.DataAccess.Entity.Mappings
{
    public class AgendamentoMap
        : IEntityTypeConfiguration<AgendamentoEntity>
    {
        public void Configure(EntityTypeBuilder<AgendamentoEntity> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired();

            builder.Property(x => x.DataHoraInicio)
                .IsRequired();

            builder.Property(x => x.DataHoraFim)
                .IsRequired();
        }
    }
}
