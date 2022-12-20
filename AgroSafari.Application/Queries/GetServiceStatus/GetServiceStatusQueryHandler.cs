using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceStatus
{
    public class GetServiceStatusQueryHandler : IRequestHandler<GetServiceStatusQuery ,ServiceStatusViewModel>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceStatusQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceStatusViewModel> Handle(GetServiceStatusQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            var serviceStatus = new ServiceStatusViewModel(service.Id, service.Title, service.ServiceStatus);

            return serviceStatus;
        }
    }
}
