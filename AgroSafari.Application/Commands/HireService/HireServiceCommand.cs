using MediatR;

namespace AgroSafari.Application.Commands.HireService
{
    public class HireServiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public HireServiceCommand(int id)
        {
            Id = id;
        }
    }
}
