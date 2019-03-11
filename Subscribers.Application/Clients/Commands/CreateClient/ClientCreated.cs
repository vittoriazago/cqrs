using MediatR;
using Subscribers.Application.Interfaces;
using Subscribers.Application.Notifications.Models;
using Subscribers.Domain.Entities;
using Subscribers.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribers.Application.Clients.Commands
{
    public class ClientCreated : INotification
    {
        public Guid ClientId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<ClientCreated>
        {
            private readonly INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ClientCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
