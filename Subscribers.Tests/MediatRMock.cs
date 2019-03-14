using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribers.Tests
{
    public class MediatRMock : IMediator
    {
        protected List<object> notifications;

        public MediatRMock()
        {
            notifications = new List<object>();
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default(CancellationToken))
        {
            notifications.Add(notification);
            return Task.FromResult<object>(null); 
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
        {
            notifications.Add(notification);
            return Task.FromResult<object>(null);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var notification = notifications.FirstOrDefault();
            notifications = notifications.Skip(1).ToList();

            return Task.FromResult<TResponse>((TResponse)notification);
        }
    }

}
