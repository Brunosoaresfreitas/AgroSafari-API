using AgroSafari.Application.Commands.CreateServiceProvider;
using AgroSafari.Application.Commands.DeleteServiceProvider;
using AgroSafari.Application.Commands.UpdateClient;
using AgroSafari.Application.Queries.GetAllServiceProviders;
using AgroSafari.Application.Queries.GetServiceProviderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSafariAPI.Controllers
{
    [Route("api/serviceProviders")]
    public class ServiceProviderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceProviderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var command = new GetAllServiceProvidersQuery(query);

            var servicesProviders = await _mediator.Send(command);

            return Ok(servicesProviders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetServiceProviderByIdQuery(id);

            var serviceProvider = await _mediator.Send(query);

            if (serviceProvider == null) return null;

            return Ok(serviceProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceProviderCommand command)
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
            var command = new DeleteServiceProviderCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
