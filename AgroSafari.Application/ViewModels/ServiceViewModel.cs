namespace AgroSafari.Application.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }

    }
}
