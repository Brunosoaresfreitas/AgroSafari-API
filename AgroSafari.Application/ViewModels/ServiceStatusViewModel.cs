using AgroSafari.Core.Enums;

namespace AgroSafari.Application.ViewModels
{
    public class ServiceStatusViewModel
    {
        public ServiceStatusViewModel(int id, string title, ServiceStatusEnum serviceStatus)
        {
            Id = id;
            Title = title;
            ServiceStatus = serviceStatus;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public ServiceStatusEnum ServiceStatus { get; private set; }
    }
}
