using System;

namespace Subscribers.Domain
{
    public class Subscriber
    {
        Guid SubscriberId { get; set; }

        Guid ClientId { get; set; }

        Guid ServiceId { get; set; }

        DateTime SubscribeDate { get; set; }

        DateTime? UnsubscribeDate { get; set; }

        bool Active { get; set; }
    }
}
