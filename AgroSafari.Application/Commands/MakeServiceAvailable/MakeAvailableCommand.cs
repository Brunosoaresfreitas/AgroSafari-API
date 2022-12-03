using MediatR;

namespace AgroSafari.Application.Commands.MakeServiceAvailable
{
    public class MakeAvailableCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public MakeAvailableCommand(int id)
        {
            Id = id;
        }
    }
}
