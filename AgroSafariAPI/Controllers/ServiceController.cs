using AgroSafari.Application.Commands.CreateService;
using AgroSafari.Application.Commands.DeleteService;
using AgroSafari.Application.Commands.UpdateService;
using AgroSafari.Application.Queries.GetAllServices;
using AgroSafari.Application.Queries.GetServiceById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSafariAPI.Controllers
{
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllServicesQuery = new GetAllServicesQuery(query);

            var services = await _mediator.Send(getAllServicesQuery);

            return Ok(services);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetServiceByIdQuery(id);

            var service = await _mediator.Send(query);

            if (service == null) return null;

            return Ok(service);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
