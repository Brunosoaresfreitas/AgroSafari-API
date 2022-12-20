using MediatR;

namespace AgroSafari.Application.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
