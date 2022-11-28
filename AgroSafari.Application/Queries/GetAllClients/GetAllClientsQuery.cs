using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Entities;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<ClientViewModel>>
    {
        public string Query { get; private set; }
        public GetAllClientsQuery(string query)
        {
            Query = query;
        }
    }
}
