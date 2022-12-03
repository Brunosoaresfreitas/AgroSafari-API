using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.CheckServiceStatus
{
    public class CheckServiceStatusCommandHandler : IRequestHandler<CheckServiceStatusCommand, ServiceStatusViewModel>
    {
        private readonly IServiceRepository _serviceRepository;

        public CheckServiceStatusCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceStatusViewModel> Handle(CheckServiceStatusCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.ServiceId);

            if (service == null) return null;

            var serviceStatus = new ServiceStatusViewModel(
                service.Id,
                service.Title,
                service.ServiceStatus);

            return serviceStatus;
        }
    }
}
