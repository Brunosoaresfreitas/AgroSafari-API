using MediatR;

namespace AgroSafari.Application.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteClientCommand(int id)
        {
            Id = id;
        }
    }
}
