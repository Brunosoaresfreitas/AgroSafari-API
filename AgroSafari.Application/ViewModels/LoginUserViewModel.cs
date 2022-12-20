namespace AgroSafari.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(int id, string email, string token)
        {
            Id = id;
            Email = email;
            Token = token;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
