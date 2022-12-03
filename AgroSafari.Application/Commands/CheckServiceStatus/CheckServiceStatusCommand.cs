using AgroSafari.Application.ViewModels;
using AgroSafari.Core.Enums;
using MediatR;

namespace AgroSafari.Application.Commands.CheckServiceStatus
{
    public class CheckServiceStatusCommand : IRequest<ServiceStatusViewModel>
    {
        public int ServiceId { get; private set; }

        public CheckServiceStatusCommand(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
