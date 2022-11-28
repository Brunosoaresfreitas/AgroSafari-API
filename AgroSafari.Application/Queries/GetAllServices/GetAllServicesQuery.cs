using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllServices
{
    public class GetAllServicesQuery : IRequest<List<ServiceViewModel>>
    {
        public string Query { get; private set; }

        public GetAllServicesQuery(string query)
        {
            Query = query;
        }
    }
}
