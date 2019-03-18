using MediatR;
using Microsoft.EntityFrameworkCore;
using Subscribers.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribers.Application.Clients.Queries
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, List<ClientsListModel>>
    {
        private readonly SubscribersDbContext _context;

        public GetClientsListQueryHandler(SubscribersDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientsListModel>> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Clients.Select(c => new ClientsListModel()
            {
                ClientId = c.ClientId,
                BirthDate = c.BirthDate,
                Name = c.Name
            }).ToListAsync(cancellationToken);
        }
    }
}
