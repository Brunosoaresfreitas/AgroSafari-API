using MediatR;

namespace AgroSafari.Application.Commands.UpdateServiceProvider
{
    public class UpdateServiceProviderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
    }
}
