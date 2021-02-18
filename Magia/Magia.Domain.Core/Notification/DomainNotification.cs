using System;
using System.Collections.Generic;
using System.Text;

namespace Magia.Domain.Core.Notification
{
    public class DomainNotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime DataHora { get; private set; }
        public int Versao { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Versao = 1;
            DataHora = DateTime.Now;
        }
    }
}
