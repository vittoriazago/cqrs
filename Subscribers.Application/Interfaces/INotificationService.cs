using Subscribers.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
