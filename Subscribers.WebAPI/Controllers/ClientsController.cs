using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Application.Clients.Commands;

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
    }
}
