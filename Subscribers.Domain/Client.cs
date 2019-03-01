using System;
using System.Collections.Generic;

namespace Subscribers.Domain
{
    public class Client
    {
        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }


        public ICollection<Service> Services { get; set; }
    }
}
