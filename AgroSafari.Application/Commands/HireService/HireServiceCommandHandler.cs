using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.HireService
{
    public class HireServiceCommandHandler : IRequestHandler<HireServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;

        public HireServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Unit> Handle(HireServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            service.Hire(request.IdClient);

            await _serviceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
