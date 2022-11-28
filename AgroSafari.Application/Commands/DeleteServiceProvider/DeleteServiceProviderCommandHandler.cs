using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.DeleteServiceProvider
{
    public class DeleteServiceProviderCommandHandler : IRequestHandler<DeleteServiceProviderCommand, Unit>
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;

        public DeleteServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository)
        {
            _serviceProviderRepository = serviceProviderRepository;
        }

        public async Task<Unit> Handle(DeleteServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _serviceProviderRepository.GetByIdAsync(request.Id);

            await _serviceProviderRepository.DeleteAsync(serviceProvider);
            await _serviceProviderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
