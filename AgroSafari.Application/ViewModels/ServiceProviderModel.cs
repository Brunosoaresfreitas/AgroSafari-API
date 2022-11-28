namespace AgroSafari.Application.ViewModels
{
    public class ServiceProviderModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cnpj { get; private set; }

        public ServiceProviderModel(string fullName, string email, int age, string cnpj)
        {
            FullName = fullName;
            Email = email;
            Age = age;
            Cnpj = cnpj;
        }
    }
}
