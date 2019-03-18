using System;
using System.Collections.Generic;
using System.Text;

namespace Subscribers.Application.Clients.Queries
{
    public class ClientsListModel
    {
        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
