using MediatR;

namespace AgroSafari.Application.Commands.HireService
{
    public class HireServiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdClient { get; set; }

        public HireServiceCommand(int id, int idClient)
        {
            Id = id;
            IdClient = idClient;
        }
    }
}
