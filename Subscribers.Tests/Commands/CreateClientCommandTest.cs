using NUnit.Framework;
using Subscribers.Application.Clients.Commands;
using Subscribers.Persistence;
using Subscribers.Tests;
using System;
using System.Threading.Tasks;

namespace Subscribers.Tests.Commands
{
    public class CreateClientCommandTest
    {
        private SubscribersDbContext _dbContext;
        private CreateClientCommand.Handler _command;

        [SetUp]
        public void Setup()
        {
            _dbContext = DbContextMock.GetDbContext();
            var mediator = new MediatRMock();
            var notificator = new NotificationMock();
            _command = new CreateClientCommand.Handler(_dbContext, notificator, mediator);
        }

        [Test]
        public async Task CreateClientCommand_Sucess()
        {
            var client = new CreateClientCommand
            {
                ClientId = Guid.NewGuid(),
                BirthDate = DateTime.MinValue,
                Name = "Client Test"
            };
            await _command.Handle(client, System.Threading.CancellationToken.None);
            
            var clientFound = await _dbContext.Clients.FindAsync(client.ClientId);
            
            Assert.AreEqual(client.ClientId, clientFound.ClientId);
        }
    }
}