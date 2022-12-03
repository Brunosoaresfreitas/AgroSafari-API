using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.FinishService
{
    public class FinishServiceCommandHandler : IRequestHandler<FinishServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;

        public FinishServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Unit> Handle(FinishServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            service.Finish();

            await _serviceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
