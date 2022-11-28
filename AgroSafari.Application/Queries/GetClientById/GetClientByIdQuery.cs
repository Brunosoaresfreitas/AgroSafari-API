using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientViewModel>
    {
        public GetClientByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
