using AgroSafari.Application.Commands.CreateService;
using AgroSafari.Application.Commands.DeleteService;
using AgroSafari.Application.Commands.FinishService;
using AgroSafari.Application.Commands.HireService;
using AgroSafari.Application.Commands.MakeServiceAvailable;
using AgroSafari.Application.Commands.UpdateService;
using AgroSafari.Application.Queries.GetAllServices;
using AgroSafari.Application.Queries.GetServiceById;
using AgroSafari.Application.Queries.GetServiceStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Client, ServiceProvider")]
        public async Task<IActionResult> Get(string? query)
        {
            var getAllServicesQuery = new GetAllServicesQuery(query);

            var services = await _mediator.Send(getAllServicesQuery);

            return Ok(services);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Client, ServiceProvider")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetServiceByIdQuery(id);

            var service = await _mediator.Send(query);

            if (service == null) return null;

            return Ok(service);
        }


        [HttpPost]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<IActionResult> Post([FromBody] CreateServiceCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/MakeAvailable")]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<IActionResult> MakeAvailable(int id)
        {
            var command = new MakeAvailableCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpPut("{id}/Hire")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Hire(int id, int idClient)
        {
            var command = new HireServiceCommand(id, idClient);

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpPut("{id}/finish")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishServiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Status")]
        [Authorize(Roles = "Client, ServiceProvider")]
        public async Task<IActionResult> GetServiceStatus(int id)
        {
            var query = new GetServiceStatusQuery(id);

            var serviceStatus = await _mediator.Send(query);

            return Ok(serviceStatus);
        }
    }
}
