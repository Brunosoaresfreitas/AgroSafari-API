using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientViewModel>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null) return null;

            var clientViewModel = new ClientViewModel(
                client.Id,
                client.FullName,
                client.Email,
                client.Age,
                client.Cpf);

            return clientViewModel; 
        }
    }
}
