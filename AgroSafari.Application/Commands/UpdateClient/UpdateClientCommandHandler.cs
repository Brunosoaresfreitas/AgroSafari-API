using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            client.Update(request.FullName, request.Email, request.BirthDate, request.Cpf);

            await _clientRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
