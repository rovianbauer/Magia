using Flunt.Validations;
using Magia.Domain.Core.Entities;
using System;

namespace Magia.Domain.AgendamentoContext.Entities
{
    public class SalaEntity : BaseEntity<Guid>
    {
        protected SalaEntity() { }

        public SalaEntity(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            DataHoraCriacao = DateTime.Now;
            Deletado = false;
        }

        public string Descricao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public bool Deletado { get; set; }

        public override void Validar()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Descricao, "", "Descrição é obrigatória")
                .HasMinLen(Descricao, 3, "", "Descrição deve ter ao menos 3 caracteres"));

            AddNotifications(new Contract()
                .IsFalse(DataHoraCriacao == null || DataHoraCriacao == DateTime.MinValue, "", $"Data Hora Criação não pode ser null"));
        }

        public override bool IsValid()
        {
            Validar();
            return Valid;
        }
    }
}
