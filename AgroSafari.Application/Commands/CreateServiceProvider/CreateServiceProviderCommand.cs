using AgroSafari.Core.Entities;
using MediatR;

namespace AgroSafari.Application.Commands.CreateServiceProvider
{
    public class CreateServiceProviderCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
    }
}
