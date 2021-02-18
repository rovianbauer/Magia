using Flunt.Validations;
using Magia.Domain.Core.Commands;
using MediatR;
using System;
using System.Globalization;

namespace Magia.Application.Agendamento.Commands
{
    public class NovoAgendamentoCommand :
        BaseCommand, IRequest<bool>
    {
        public Guid SalaId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public override bool IsValid()
        {
            return IsValid();
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsFalse(SalaId == Guid.Empty, "SalaId", "SalaId é obrigatória"));

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
    }
}
