using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyFinances.Core.Aggregates;
using MyFinances.Infra.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFinances.Infra.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration Configuration { get; }
        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public TokenDto GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            string key = Configuration.GetSection("JwtConfig:Key").Value;
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };


            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            var expiresIn = (tokenDescriptor.Expires.Value - DateTime.Today).TotalSeconds;

            var tokenDto = new TokenDto(accessToken, expiresIn);
            return tokenDto;


        }
    }
}
