using AgroSafari.Application.Commands.CreateClient;
using AgroSafari.Application.Commands.DeleteClient;
using AgroSafari.Application.Commands.LoginClient;
using AgroSafari.Application.Commands.UpdateClient;
using AgroSafari.Application.Queries.GetAllClients;
using AgroSafari.Application.Queries.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSafariAPI.Controllers
{
    [Route("api/clients")]

    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllClientsQuery = new GetAllClientsQuery(query);

            var clients = await _mediator.Send(getAllClientsQuery);

            return Ok(clients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetClientByIdQuery(id);

            var client = await _mediator.Send(query);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Update([FromBody] UpdateClientCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClientCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginClientCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null) 
            {
                return BadRequest();
            }
            
            return Ok(loginUserViewModel);
        }
    }
}
