using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Commands.LoginServiceProvider
{
    public class LoginServiceProviderCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
