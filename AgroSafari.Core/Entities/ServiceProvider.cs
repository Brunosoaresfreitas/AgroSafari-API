namespace AgroSafari.Core.Entities
{
    public class ServiceProvider : BaseEntity
    {
        public ServiceProvider(string fullName, string email, int age, string cnpj)
        {
            FullName = fullName;
            Email = email;
            Age = age;
            Cnpj = cnpj;

            CreatedAt = DateTime.Now;

            OwnedServices = new List<Service>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Service> OwnedServices { get; private set; }

        public void Update(string fullName, string email, int age, string cnpj)
        {
            FullName = fullName;
            Email = email;
            Age = age;
            Cnpj = cnpj;
        }
    }
}
