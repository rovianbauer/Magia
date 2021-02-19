using Flunt.Validations;
using Magia.Domain.Core.Commands;
using MediatR;

namespace Magia.Application.AgendamentoContext.Commands
{
    public class NovaSalaCommand
        : BaseCommand, IRequest<bool>
    {
        public string Descricao { get; set; }

        public override bool IsValid()
        {
            return Valid;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Descricao, "", "Descrição é obrigatório")
               .HasMinLen(Descricao, 3, "", "Descrição deve ser maior que 3 caracteres"));
        }
    }
}
