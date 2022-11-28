using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceProviderById
{
    public class GetServiceProviderByIdQuery : IRequest<ServiceProviderModel>
    {
        public int Id { get; private set; }
        public GetServiceProviderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
