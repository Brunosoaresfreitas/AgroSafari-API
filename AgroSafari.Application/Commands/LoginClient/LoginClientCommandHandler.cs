using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using AgroSafari.Core.Services;
using MediatR;

namespace AgroSafari.Application.Commands.LoginClient
{
    public class LoginClientCommandHandler : IRequestHandler<LoginClientCommand, LoginUserViewModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAuthService _authService;
        public LoginClientCommandHandler(IClientRepository clientRepository, IAuthService authService)
        {
            _clientRepository = clientRepository;
            _authService = authService;
        }
        public async Task<LoginUserViewModel> Handle(LoginClientCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Buscar no banco de dados um client com o email e a senha em formato hash
            var user = await _clientRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // Se não existir, erro no login
            if (user == null) return null;

            // Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Id, user.Email, token);
        }
    }
}
