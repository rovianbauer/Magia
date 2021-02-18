using Flunt.Validations;
using Magia.Domain.Core.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Domain.Core.Commands
{
    public class ValidateCommandPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        public ValidateCommandPipelineBehavior(IDomainNotificationHandler notification)
        {
            _notification = notification;
        }

        private readonly IDomainNotificationHandler _notification;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IValidatable validatable)
            {
                if (validatable is BaseCommand command)
                {
                    command.Validate();

                    if (command.Invalid)
                    {
                        foreach (var notify in command.Notifications)
                            _notification.Add(notify.Message);

                        return default(TResponse);
                    }
                }
            }

            if (next != null)
            {
                var result = await next();

                return result;
            }

            return default(TResponse);
        }
    }
}
