using MediatR;

namespace AgroSafari.Application.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteServiceCommand(int id)
        {
            Id = id;
        }
    }
}
