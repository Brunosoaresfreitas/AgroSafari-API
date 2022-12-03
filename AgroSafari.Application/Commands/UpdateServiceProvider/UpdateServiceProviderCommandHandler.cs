using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.UpdateServiceProvider
{
    public class UpdateServiceProviderCommandHandler : IRequestHandler<UpdateServiceProviderCommand, Unit>
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;

        public UpdateServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository)
        {
            _serviceProviderRepository = serviceProviderRepository;
        }

        public async Task<Unit> Handle(UpdateServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProviderToBeUpdated = await _serviceProviderRepository.GetByIdAsync(request.Id);

            serviceProviderToBeUpdated.Update(request.FullName, request.Email, request.Cnpj);
            await _serviceProviderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
