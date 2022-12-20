using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using AgroSafari.Core.Services;
using MediatR;

namespace AgroSafari.Application.Commands.CreateServiceProvider
{
    public class CreateServiceProviderCommandHandler : IRequestHandler<CreateServiceProviderCommand, int>
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IAuthService _authService;

        public CreateServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository, IAuthService authService)
        {
            _serviceProviderRepository = serviceProviderRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var serviceProvider = new ServiceProvider(request.FullName, request.Email, passwordHash, request.Cnpj);

            await _serviceProviderRepository.CreateAsync(serviceProvider);
            await _serviceProviderRepository.SaveChangesAsync();

            return serviceProvider.Id;
        }
    }
}
