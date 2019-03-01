using System;

namespace Subscribers.Domain
{
    public class Subscriber
    {
        public Guid SubscriberId { get; set; }

        public Guid ClientId { get; set; }

        public Guid ServiceId { get; set; }

        public DateTime SubscribeDate { get; set; }

        public DateTime? UnsubscribeDate { get; set; }

        public bool Active { get; set; }


        public Client Client { get; set; }

        public Service Service { get; set; }
    }
}
