using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.MakeServiceAvailable
{
    public class MakeAvailableCommandHandler : IRequestHandler<MakeAvailableCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;

        public MakeAvailableCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        public async Task<Unit> Handle(MakeAvailableCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            service.MakeAvailable();

            await _serviceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
