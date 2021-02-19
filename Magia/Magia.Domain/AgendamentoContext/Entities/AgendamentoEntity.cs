using Flunt.Validations;
using Magia.Domain.Core.Entities;
using System;
using System.Globalization;

namespace Magia.Domain.AgendamentoContext.Entities
{
    public class AgendamentoEntity : BaseEntity<Guid>
    {
        protected AgendamentoEntity() { }

        public AgendamentoEntity(SalaEntity sala,
            string titulo,
            DateTime dataHoraInicio,
            DateTime dataHoraFim)
        {
            Id = Guid.NewGuid();
            Sala = sala;
            Titulo = titulo;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
        }

        public SalaEntity Sala { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public override void Validar()
        {
            AddNotifications(new Contract()
               .IsFalse(Sala == null, "Sala", "Sala é obrigatória"));

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Titulo, "", "Título é obrigatório")
                .HasMinLen(Titulo, 3, "", "Título deve ser maior que 3 caracteres"));

            AddNotifications(new Contract()
               .IsGreaterOrEqualsThan(DataHoraInicio, DateTime.Now, "", $"Data hora inicio não pode ser anterior a data atual {DateTime.Now.ToString("F", new CultureInfo("pt-BR"))}"));

            AddNotifications(new Contract()
               .IsFalse(DataHoraFim == null, "DataHoraFim", "Data hora fim é obrigatória")
               .IsGreaterOrEqualsThan(DataHoraFim, DateTime.MinValue, "DataHoraFim", $"Data hora fim é obrigatória")
               .IsGreaterThan(DataHoraFim, DataHoraInicio, "DataHoraFim", $"Data hora fim deve ser maior que a data hora inicio"));
        }

        public override bool IsValid()
        {
            Validar();
            return Valid;
        }
    }
}
