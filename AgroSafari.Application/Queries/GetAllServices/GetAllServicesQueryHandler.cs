using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllServices
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceViewModel>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServicesQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceViewModel>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var query = await _serviceRepository.GetAllAsync(request.Query);

            if (query == null) return null;

            var services = query
                .Select(s => new ServiceViewModel(s.Id, s.Title, s.Description, s.TotalCost))
                .ToList();

            return services;
        }
    }
}
