using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magia.WebAPI.Configuration
{
    public class ErrorResponse
    {
        public ErrorResponse(List<string> notifications)
        {
            this.Notifications = notifications;
        }

        public List<string> Notifications { get; set; }
    }
}
