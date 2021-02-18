using System.Collections.Generic;
using System.Linq;

namespace Magia.Domain.Core.Notification
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Add(string value)
        {
            Add(string.Empty, value);
        }

        public void Add(string key, string value)
        {
            _notifications.Add(new DomainNotification(key, value));
        }

        public void Dispose()
        {
            _notifications.Clear();
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return GetNotifications(false);
        }

        public IEnumerable<DomainNotification> GetNotifications(bool distintas)
        {
            if (distintas)
                return _notifications
                    .GroupBy(x => new { x.Key, x.Value, x.Versao })
                    .Select(x => x.First());

            return _notifications;
        }

        public bool HasNotifications => _notifications.Any();
    }
}
