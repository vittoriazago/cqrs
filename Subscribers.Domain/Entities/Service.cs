using System;
using System.Collections;
using System.Collections.Generic;

namespace Subscribers.Domain.Entities
{
    public class Service
    {
        public Service()
        {
            Subscribers = new HashSet<Subscriber>();
        }

        public Guid ServiceId { get; set; }

        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }


        public ICollection<Subscriber> Subscribers { get; private set; }
    }
}
