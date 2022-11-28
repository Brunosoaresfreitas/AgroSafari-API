using MediatR;

namespace AgroSafari.Application.Commands.DeleteServiceProvider
{
    public class DeleteServiceProviderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteServiceProviderCommand(int id)
        {
            Id = id;
        }
    }
}
