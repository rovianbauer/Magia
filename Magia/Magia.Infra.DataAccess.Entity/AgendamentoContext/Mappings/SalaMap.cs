using Magia.Domain.AgendamentoContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Magia.Infra.DataAccess.Entity.AgendamentoContext.Mappings
{
    public class SalaMap
        : IEntityTypeConfiguration<SalaEntity>
    {
        public void Configure(EntityTypeBuilder<SalaEntity> builder)
        {
            builder.ToTable("Sala");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired();

            builder.Property(x => x.DataHoraCriacao)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Deletado)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
