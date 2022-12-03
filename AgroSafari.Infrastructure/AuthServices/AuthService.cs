using AgroSafari.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AgroSafari.Infrastructure.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute Hash - retorna byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte byte array para string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2")); // x2 faz com que seja convertido em representação hexadecimal
                }

                return builder.ToString();
            }
        }

        public string GenerateJwtToken(string email, string role)
        {
            // 1° Passo é recuperar as três informações definidas na configuração (appsettings)
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // As credentials vão ser utilizadas posteriormente para assinar o token com todas as informações, com o algoritmo e os dados do meu token Jwt
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // O claim é uma informação sobre o usuário ao qual o token pertence
            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials,
                claims: claims);

            // Para gerar a cadeia de caracteres utilizamos uma instância de JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();  

            // E o token em formato de string vai ser simplesmente esse handler acima, com o método WriteToken recebendo um JwtSecurityToken, que foi configurado acima
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
