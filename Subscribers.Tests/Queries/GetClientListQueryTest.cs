using NUnit.Framework;
using Subscribers.Application.Clients.Queries;
using Subscribers.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers.Tests.Queries
{
    public class GetClientListQueryTest
    {
        private SubscribersDbContext _dbContext;
        private GetClientsListQueryHandler _query;

        [SetUp]
        public void Setup()
        {
            _dbContext = DbContextMock.GetDbContext();
            _query = new GetClientsListQueryHandler(_dbContext);
        }

        [Test]
        public async Task GetClientsListQuery_Sucess_Empty()
        {
            var query = new GetClientsListQuery();

            var clients = await _query.Handle(query, System.Threading.CancellationToken.None);

            Assert.AreEqual(0, clients.Count);
        }

        [Test]
        public async Task GetClientsListQuery_Sucess_NotEmpty()
        {
            _dbContext.Clients.Add(new Domain.Entities.Client()
            {
                ClientId = Guid.NewGuid(),
                Name = "Mock client"
            });
            _dbContext.SaveChanges();

            var query = new GetClientsListQuery();
            var clients = await _query.Handle(query, System.Threading.CancellationToken.None);
            
            Assert.AreEqual(1, clients.Count);
        }
    }
}
