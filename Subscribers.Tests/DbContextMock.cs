using Microsoft.EntityFrameworkCore;
using Subscribers.Persistence;
using System;

namespace Subscribers.Tests
{
    public class DbContextMock
    {
        public static SubscribersDbContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<SubscribersDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            
            var dbContext = new SubscribersDbContext(builder.Options);  
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
