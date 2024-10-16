

using Authentication.Service.API.Models;
using JwtConfiguration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Service.API.Services
{
    public class TokenService: ITokenService<User>
    {
            private readonly string key;
            private readonly string issuer;
            private readonly string audience;

            public TokenService(IConfiguration configuration)
            {
                key = JwtConfigData.Key ?? "";
                issuer = JwtConfigData.ValidIssuer ?? "";
                audience = JwtConfigData.ValidAudience ?? "";
            }

            public  string GenerateToken(User user)
            {
                var claims = new[]
                {
                  new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

    }
}
