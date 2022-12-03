using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using AgroSafari.Core.Services;
using MediatR;

namespace AgroSafari.Application.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAuthService _authService;

        public CreateClientCommandHandler(IClientRepository clientRepository, IAuthService authService)
        {
            _clientRepository = clientRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var client = new Client(request.FullName, request.Email, passwordHash, request.Cpf, request.BirthDate);

            await _clientRepository.CreateAsync(client);
            await _clientRepository.SaveChangesAsync();

            return client.Id;
        }
    }   
}
