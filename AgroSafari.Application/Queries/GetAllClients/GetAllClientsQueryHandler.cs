using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientViewModel>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();

            if (clients == null) return null;

            var clientViewModel = clients
                .Select(c => new ClientViewModel(c.Id, c.FullName, c.Email, c.Age, c.Cpf))
                .ToList();

            return clientViewModel;
        }
    }
}
