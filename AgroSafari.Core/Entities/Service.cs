using AgroSafari.Core.Enums;
using System;

namespace AgroSafari.Core.Entities
{
    public class Service : BaseEntity
    {
        public Service(string title, string description, int idServiceProvider, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdServiceProvider = idServiceProvider;
            TotalCost = totalCost;
            PostedAt = DateTime.Now;
            ServiceStatus = ServiceStatusEnum.Created;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public ServiceProvider ServiceProvider { get; private set; }
        public int IdServiceProvider { get; private set; }
        public Client? Client { get; private set; }
        public int? IdClient { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? PostedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ServiceStatusEnum ServiceStatus { get; private set; }


        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void MakeAvailable()
        {
            if (ServiceStatus == ServiceStatusEnum.Created)
            {
                ServiceStatus = ServiceStatusEnum.Available;
            }
        }

        public void Hire(int idClient)
        {
            if (ServiceStatus == ServiceStatusEnum.Available)
            {
                ServiceStatus = ServiceStatusEnum.Hired;
                IdClient = idClient;
            }
        }

        public void Finish()
        {
            if (ServiceStatus == ServiceStatusEnum.Hired)
            {
                ServiceStatus = ServiceStatusEnum.Finished;
            }
        }
    }
}
