namespace AgroSafari.Application.InputModels
{
    public class UpdateClientInputModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
