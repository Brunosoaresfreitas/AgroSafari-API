using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceProviderById
{
    public class GetServiceProviderByIdQueryHandler : IRequestHandler<GetServiceProviderByIdQuery, ServiceProviderModel>
    {
        private readonly IServiceProviderRepository _serviceProvider;

        public GetServiceProviderByIdQueryHandler(IServiceProviderRepository serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ServiceProviderModel> Handle(GetServiceProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _serviceProvider.GetByIdAsync(request.Id);

            if (serviceProvider == null) return null;

            var serviceProviderId = new ServiceProviderModel(
                serviceProvider.FullName,
                serviceProvider.Email,
                serviceProvider.Age,
                serviceProvider.Cnpj);

            return serviceProviderId;
        }
    }
}
