using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using MediatR;

namespace AgroSafari.Application.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToBeUpdated = await _serviceRepository.GetByIdAsync(request.Id);

            serviceToBeUpdated.Update(request.Title, request.Description, request.TotalCost);

            await _serviceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
