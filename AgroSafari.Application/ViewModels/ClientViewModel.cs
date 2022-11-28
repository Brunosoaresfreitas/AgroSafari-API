namespace AgroSafari.Application.ViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(int id, string fullName, string email, int age, string cpf)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Age = age;
            Cpf = cpf;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cpf { get; private set; }
    }
}
