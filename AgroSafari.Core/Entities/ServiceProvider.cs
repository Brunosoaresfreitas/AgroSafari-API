namespace AgroSafari.Core.Entities
{
    public class ServiceProvider : BaseEntity
    {
        public ServiceProvider(string fullName, string email, string password, string cnpj)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Cnpj = cnpj;

            CreatedAt = DateTime.Now;

            OwnedServices = new List<Service>();
            Role = "ServiceProvider";
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Cnpj { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Service> OwnedServices { get; private set; }

        public void Update(string fullName, string email, string cnpj)
        {
            FullName = fullName;
            Email = email;
            Cnpj = cnpj;
        }
    }
}
