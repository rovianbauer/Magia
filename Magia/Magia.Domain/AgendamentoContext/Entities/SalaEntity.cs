using Magia.Domain.Core.Entities;
using System;

namespace Magia.Domain.AgendamentoContext.Entities
{
    public class SalaEntity : BaseEntity<Guid>
    {
        public string Descricao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public bool Deletado { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
