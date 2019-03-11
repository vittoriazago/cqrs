using Subscribers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subscribers.Persistence
{
    public class SubscribersSeed
    {
        private readonly Dictionary<int, Service> Services = new Dictionary<int, Service>();
        private readonly Dictionary<int, Client> Clients = new Dictionary<int, Client>();
        private readonly Dictionary<int, Subscriber> Subscribers = new Dictionary<int, Subscriber>();

        public static void Initialize(SubscribersDbContext context)
        {
            var initializer = new SubscribersSeed();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(SubscribersDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return; // Db has been seeded
            }

            var clients = SeedClients(context);
            var services = SeedServices(context);
            SeedSubscribers(context, clients, services);
        }

        public Client[] SeedClients(SubscribersDbContext context)
        {
            var clients = new[]
            {
                new Client { ClientId = Guid.NewGuid(), Name = "Maria Anders", BirthDate = DateTime.ParseExact("1979-11-01", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Client { ClientId = Guid.NewGuid(), Name = "Ana Trujillo",  BirthDate = DateTime.ParseExact("1993-02-27", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Client { ClientId = Guid.NewGuid(), Name = "Antonio Moreno",  BirthDate = DateTime.ParseExact("1995-12-11", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Client { ClientId = Guid.NewGuid(), Name = "Thomas Hardy",  BirthDate = DateTime.ParseExact("1990-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Client { ClientId = Guid.NewGuid(), Name = "Christina Berglund",  BirthDate = DateTime.ParseExact("1980-05-30", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Client { ClientId = Guid.NewGuid(), Name = "Hanna Moos", BirthDate = DateTime.ParseExact("1982-10-10", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Client { ClientId = Guid.NewGuid(), Name = "Frédérique Citeaux", BirthDate = DateTime.ParseExact("1999-06-20", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Client { ClientId = Guid.NewGuid(), Name = "Martín Sommer", BirthDate = DateTime.ParseExact("1971-01-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return clients;
        }

        public Service[] SeedServices(SubscribersDbContext context)
        {
            var services = new[]
            {
                new Service { ServiceId = Guid.NewGuid(), Name = "Clothes Sale", RegisterDate = DateTime.ParseExact("2011-11-01", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Service { ServiceId = Guid.NewGuid(), Name = "Scientific journals",  RegisterDate = DateTime.ParseExact("2002-02-27", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Service { ServiceId = Guid.NewGuid(), Name = "Sportive articles",  RegisterDate = DateTime.ParseExact("2019-02-11", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Service { ServiceId = Guid.NewGuid(), Name = "Famous gossip",  RegisterDate = DateTime.ParseExact("2018-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Service { ServiceId = Guid.NewGuid(), Name = "Travel discounts",  RegisterDate = DateTime.ParseExact("2018-05-30", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Service { ServiceId = Guid.NewGuid(), Name = "New Courses", RegisterDate = DateTime.ParseExact("2015-10-10", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
            };

            context.Services.AddRange(services);
            context.SaveChanges();

            return services;
        }

        public Subscriber[] SeedSubscribers(SubscribersDbContext context, Client[] clients, Service[] services)
        {
            var Subscribers = new[]
            {
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(1).ClientId, ServiceId = services.ElementAt(2).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-3), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(1).ClientId, ServiceId = services.ElementAt(3).ServiceId, Active = false, SubscribeDate = DateTime.Today.AddMonths(-1), UnsubscribeDate = DateTime.Now },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(1).ClientId, ServiceId = services.ElementAt(3).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-1), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(1).ClientId, ServiceId = services.ElementAt(5).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-1), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(2).ClientId, ServiceId = services.ElementAt(2).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-20), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(3).ClientId, ServiceId = services.ElementAt(4).ServiceId, Active = false, SubscribeDate = DateTime.Today.AddMonths(-8), UnsubscribeDate = DateTime.Now },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(4).ClientId, ServiceId = services.ElementAt(5).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-10), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(0).ClientId, ServiceId = services.ElementAt(5).ServiceId, Active = false, SubscribeDate = DateTime.Today.AddMonths(-10), UnsubscribeDate = DateTime.Now },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(5).ClientId, ServiceId = services.ElementAt(1).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-3), UnsubscribeDate = null },
                new Subscriber { SubscriberId = Guid.NewGuid(), ClientId = clients.ElementAt(5).ClientId, ServiceId = services.ElementAt(1).ServiceId, Active = true, SubscribeDate = DateTime.Today.AddMonths(-3), UnsubscribeDate = null },
            };

            context.Subscribers.AddRange(Subscribers);
            context.SaveChanges();

            return Subscribers;
        }

    }
}
