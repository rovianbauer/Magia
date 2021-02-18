using System;
using System.Collections.Generic;
using System.Text;

namespace Magia.Domain.Core.Notification
{
    public interface IDomainNotificationHandler : IDisposable
    {
        bool HasNotifications { get; }

        IEnumerable<DomainNotification> GetNotifications();

        IEnumerable<DomainNotification> GetNotifications(bool distintas);

        void Add(string value);

        void Add(string key, string value);
    }
}
