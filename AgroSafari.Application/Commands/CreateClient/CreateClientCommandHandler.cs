using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.FullName, request.Email, request.Cpf, request.BirthDate);

            await _clientRepository.CreateAsync(client);
            await _clientRepository.SaveChangesAsync();

            return client.Id;
        }
    }   
}
