using Flunt.Validations;
using Magia.Domain.Core.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Magia.Domain.Core.Queries
{
    public class ValidateQueryPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        public ValidateQueryPipelineBehavior(IDomainNotificationHandler notification)
        {
            _notification = notification;
        }

        private readonly IDomainNotificationHandler _notification;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IValidatable validatable)
            {
                if (validatable is BaseQuery query)
                {
                    query.Validate();

                    if (query.Invalid)
                    {
                        foreach (var notify in query.Notifications)
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
