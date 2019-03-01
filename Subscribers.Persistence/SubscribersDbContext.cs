using Microsoft.EntityFrameworkCore;
using Subscribers.Domain;
using System;

namespace Subscribers.Persistence
{
    public class SubscribersDbContext : DbContext
    {
        public SubscribersDbContext(DbContextOptions<SubscribersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscribersDbContext).Assembly);
        }
    }
}
