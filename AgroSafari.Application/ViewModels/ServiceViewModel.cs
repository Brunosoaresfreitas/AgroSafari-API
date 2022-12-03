namespace AgroSafari.Application.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel(int id, string title, string description, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }

    }
}
