namespace AgroSafari.Application.ViewModels
{
    public class LoginServiceProviderViewModel
    {
        public string Email { get; private set; }
        public string Token { get; private set; }

        public LoginServiceProviderViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
