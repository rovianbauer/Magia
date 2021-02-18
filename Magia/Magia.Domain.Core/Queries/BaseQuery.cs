using Flunt.Notifications;
using Flunt.Validations;

namespace Magia.Domain.Core.Queries
{
    public abstract class BaseQuery
           : Notifiable, IValidatable
    {
        public abstract void Validate();
        public abstract bool IsValid();
    }
}
