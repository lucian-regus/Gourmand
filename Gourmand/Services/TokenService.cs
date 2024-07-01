using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gourmand.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) => _configuration = configuration; 

        public string GenerateToken(string username)
        {
            var key = _configuration["JWT:key"];
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                }),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(keyBytes),
                                        SecurityAlgorithms.HmacSha256Signature
                                        )
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);

        }
    }
}
