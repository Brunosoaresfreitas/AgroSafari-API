using MediatR;

namespace AgroSafari.Application.Commands.FinishService
{
    public class FinishServiceCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public FinishServiceCommand(int id)
        {
            Id = id;
        }
    }
}
