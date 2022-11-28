using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllServiceProviders
{
    public class GetAllServiceProvidersQueryHandler : IRequestHandler<GetAllServiceProvidersQuery, List<ServiceProviderModel>>
    {
        private readonly IServiceProviderRepository _serviceProvider;

        public GetAllServiceProvidersQueryHandler(IServiceProviderRepository serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<ServiceProviderModel>> Handle(GetAllServiceProvidersQuery request, CancellationToken cancellationToken)
        {
            var serviceProviders = await _serviceProvider.GetAllAsync();

            if (serviceProviders == null) return null;

            var serviceProviderModel = serviceProviders.Select(
                s => new ServiceProviderModel(s.FullName, s.Email, s.Age, s.Cnpj))
                .ToList();

            return serviceProviderModel;
        }
    }
}
