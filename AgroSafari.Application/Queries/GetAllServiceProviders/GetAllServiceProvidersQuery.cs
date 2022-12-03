using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Entities;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllServiceProviders
{
    public class GetAllServiceProvidersQuery : IRequest<List<ServiceProviderModel>>
    {
        public string Query { get; private set; }
        public GetAllServiceProvidersQuery(string query)
        {
            Query = query;
        }
    }
}
