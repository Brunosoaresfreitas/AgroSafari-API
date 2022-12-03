namespace AgroSafari.Application.ViewModels
{
    public class ServiceProviderModel
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Cnpj { get; private set; }

        public ServiceProviderModel(int id, string fullName, string email, string cnpj)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Cnpj = cnpj;
        }
    }
}
