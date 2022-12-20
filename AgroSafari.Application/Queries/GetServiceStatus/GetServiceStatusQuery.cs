using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceStatus
{
    public class GetServiceStatusQuery : IRequest<ServiceStatusViewModel>
    {
        public GetServiceStatusQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
