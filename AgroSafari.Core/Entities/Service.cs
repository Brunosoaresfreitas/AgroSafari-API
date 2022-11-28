using System;

namespace AgroSafari.Core.Entities
{
    public class Service : BaseEntity
    {
        public Service(string title, string description, int idServiceProvider, int idClient, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdServiceProvider = idServiceProvider;
            IdClient = idClient;
            TotalCost = totalCost;
            PostedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public ServiceProvider ServiceProvider { get; private set; }
        public int IdServiceProvider { get; private set; }
        public Client Client { get; private set; }
        public int IdClient { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? PostedAt { get; private set; }


        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
