using AgroSafari.Application.Commands.CreateClient;
using AgroSafari.Application.Commands.DeleteClient;
using AgroSafari.Application.Commands.LoginClient;
using AgroSafari.Application.Commands.UpdateClient;
using AgroSafari.Application.Queries.GetAllClients;
using AgroSafari.Application.Queries.GetClientById;
using AgroSafari.Application.ViewModels;
using MediatR;
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
        public async Task<IActionResult> Get(string query)
        {
            var getAllClientsQuery = new GetAllClientsQuery(query);

            var clients = await _mediator.Send(getAllClientsQuery);

            return Ok(clients);
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClientCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClientCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("login")]
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
