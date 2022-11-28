using MediatR;

namespace AgroSafari.Application.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
