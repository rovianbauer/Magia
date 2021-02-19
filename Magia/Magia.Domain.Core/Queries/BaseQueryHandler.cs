using AutoMapper;
using Flunt.Notifications;
using Magia.Domain.Core.Notification;

namespace Magia.Domain.Core.Queries
{
    public class BaseQueryHandler
        : Notifiable
    {
        protected readonly IDomainNotificationHandler Notification;
        protected readonly IMapper Mapper;

        public BaseQueryHandler(IDomainNotificationHandler notification,
            IMapper mapper)
        {
            Notification = notification;
            Mapper = mapper;
        }

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
