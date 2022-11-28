using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            await _clientRepository.DeleteAsync(client);
            await _clientRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
