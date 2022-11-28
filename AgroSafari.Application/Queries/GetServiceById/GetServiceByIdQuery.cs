using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Queries.GetServiceById
{
    public class GetServiceByIdQuery : IRequest<ServiceDetailViewModel>
    {
        public int Id { get; private set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
