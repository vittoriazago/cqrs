using MediatR;
using Subscribers.Application.Interfaces;
using Subscribers.Domain.Entities;
using Subscribers.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribers.Application.Clients.Commands
{
    public class CreateClientCommand : IRequest
    {
        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public class Handler : IRequestHandler<CreateClientCommand, Unit>
        {
            private readonly SubscribersDbContext _context;
            private readonly INotificationService _notificationService;
            private readonly IMediator _mediator;

            public Handler(
                SubscribersDbContext context,
                INotificationService notificationService,
                IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
                _notificationService = notificationService;
            }

            public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var entity = new Client
                {
                    Name = request.Name,
                    ClientId = request.ClientId,
                    BirthDate = request.BirthDate,
                };

                _context.Clients.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new ClientCreated { ClientId = entity.ClientId });

                return Unit.Value;
            }
        }
    }
}
