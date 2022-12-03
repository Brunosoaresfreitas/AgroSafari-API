using AgroSafari.Application.ViewModels;
using MediatR;

namespace AgroSafari.Application.Commands.LoginClient
{
    public class LoginClientCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
