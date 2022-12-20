using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Repositories;
using AgroSafari.Core.Services;
using AgroSafari.Infrastructure.Persistence.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.LoginServiceProvider
{
    public class LoginServiceProviderCommandHandler : IRequestHandler<LoginServiceProviderCommand, LoginUserViewModel>
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IAuthService _authService;

        public LoginServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository, IAuthService authService)
        {
            _serviceProviderRepository = serviceProviderRepository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginServiceProviderCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Buscar no banco de dados um client com o email e a senha em formato hash
            var user = await _serviceProviderRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // Se não existir, erro no login
            if (user == null) return null;

            // Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Id, user.Email, token);
        }
    }
}
