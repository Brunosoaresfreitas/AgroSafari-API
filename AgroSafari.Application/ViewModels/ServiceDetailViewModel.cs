using AgroSafari.Core.Entities;

namespace AgroSafari.Application.ViewModels
{
    public class ServiceDetailViewModel
    {
        public ServiceDetailViewModel(int id, string title, string description, string serviceProviderFullName, string clientFullName, decimal totalCost, DateTime? postedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            ServiceProviderFullName = serviceProviderFullName;
            ClientFullName = clientFullName;
            TotalCost = totalCost;
            PostedAt = postedAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ServiceProviderFullName { get; private set; }
        public string ClientFullName { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? PostedAt { get; private set; }
    }
}
