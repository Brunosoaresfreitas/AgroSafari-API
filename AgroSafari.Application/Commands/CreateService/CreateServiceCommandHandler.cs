using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.Title, request.Description, request.IdServiceProvider, request.IdClient, request.TotalCost);

            await _serviceRepository.CreateAsync(service);
            await _serviceRepository.SaveChangesAsync();

            return service.Id;
        }
    }
}
