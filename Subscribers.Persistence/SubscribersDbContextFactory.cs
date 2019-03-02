using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Subscribers.Persistence
{
    public class SubscribersDbContextFactory : IDesignTimeDbContextFactory<SubscribersDbContext>
    {
        private const string ConnectionStringName = "SubscribersDatabase";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public SubscribersDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SubscribersDbContext>();
            var environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() 
                    + string.Format("{0}..{0}Subscribers.WebAPI", Path.DirectorySeparatorChar))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            builder.UseSqlServer(connectionString);

            return new SubscribersDbContext(builder.Options);
        }
    }
}
