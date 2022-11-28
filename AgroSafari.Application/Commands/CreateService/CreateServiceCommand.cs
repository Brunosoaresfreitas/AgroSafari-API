using MediatR;

namespace AgroSafari.Application.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdServiceProvider { get; set; }
        public int IdClient { get; set; }
        public decimal TotalCost { get; set; }
    }
}
