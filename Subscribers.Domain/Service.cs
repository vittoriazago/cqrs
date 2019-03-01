using System;
using System.Collections;
using System.Collections.Generic;

namespace Subscribers.Domain
{
    public class Service
    {
        public Guid ServiceId { get; set; }

        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }


        public ICollection<Subscriber> Subscribers { get; set; }
    }
}
