using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscribers.Application.Clients.Queries
{
    public class GetClientsListQuery : IRequest<List<ClientsListModel>>
    {
    }
}
