using Flunt.Notifications;
using Magia.Domain.Core.Notification;
using MediatR;

namespace Magia.Domain.Core.Commands
{
    public abstract class BaseCommandHandler : Notifiable
    {
        protected BaseCommandHandler(
            IMediator mediator,
            IDomainNotificationHandler notification)
        {
            Mediator = mediator;
            Notification = notification;
        }

        protected readonly IMediator Mediator;
        protected readonly IDomainNotificationHandler Notification;

        protected void AddNotification(string notification)
        {
            Notification.Add(notification);
        }

        protected void AddNotifications(Notifiable notifiable)
        {
            if (notifiable != null && notifiable.Invalid)
                foreach (var notify in notifiable.Notifications)
                    Notification.Add(notify.Property, notify.Message);
        }
    }
}
