using Subscribers.Application.Interfaces;
using Subscribers.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Tests
{
    public class NotificationMock : INotificationService
    {
        protected List<Message> messages;

        public NotificationMock()
        {
            messages = new List<Message>();
        }

        public Task SendAsync(Message message)
        {
            messages.Add(message);
            return default(Task); 
        }
    }
}
