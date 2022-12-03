using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.CreateServiceProvider
{
    public class CreateServiceProviderCommandHandler : IRequestHandler<CreateServiceProviderCommand, int>
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;

        public CreateServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository)
        {
            _serviceProviderRepository = serviceProviderRepository;
        }

        public async Task<int> Handle(CreateServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProvider = new ServiceProvider(request.FullName, request.Email, request.Password, request.Cnpj);

            await _serviceProviderRepository.CreateAsync(serviceProvider);
            await _serviceProviderRepository.SaveChangesAsync();

            return serviceProvider.Id;
        }
    }
}
