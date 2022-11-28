using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.DeleteService
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            await _serviceRepository.DeleteAsync(service);
            await _serviceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
