using System;
using System.Collections.Generic;

namespace Subscribers.Domain.Entities
{
    public class Client
    {
        public Client()
        {
            Services = new HashSet<Subscriber>();
        }

        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }


        public ICollection<Subscriber> Services { get; private set; }
    }
}
