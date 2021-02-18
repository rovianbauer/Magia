using Flunt.Notifications;
using Flunt.Validations;

namespace Magia.Domain.Core.Commands
{
    public abstract class BaseCommand
        : Notifiable, IValidatable
    {
        public abstract bool IsValid();
        public abstract void Validate();
    }
}
