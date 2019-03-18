using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Application.Clients.Commands;
using Subscribers.Application.Clients.Queries;

namespace Subscribers.WebAPI.Controllers
{
    public class ClientsController : BaseController
    {
        // POST api/clients
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateClientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // GET api/clients
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientsListModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery]GetClientsListQuery query)
        {
            var clients =  await Mediator.Send(query);

            return Ok(clients);
        }
    }
}
