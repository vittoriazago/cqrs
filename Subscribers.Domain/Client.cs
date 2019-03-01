using System;

namespace Subscribers.Domain
{
    public class Client
    {
        Guid ClientId { get; set; }

        string Name { get; set; }

        DateTime BirthDate { get; set; }
    }
}
