using MediatR;

namespace AgroSafari.Application.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
