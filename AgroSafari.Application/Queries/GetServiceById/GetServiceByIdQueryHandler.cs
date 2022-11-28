using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceById
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDetailViewModel>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDetailViewModel> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            if (service == null) return null;

            var serviceDetail = new ServiceDetailViewModel(
                service.Title,
                service.Description,
                service.ServiceProvider.FullName,
                service.Client.FullName,
                service.TotalCost,
                service.PostedAt);

            return serviceDetail;
        }
    }
}
