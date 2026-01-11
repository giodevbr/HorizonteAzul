using HorizonteAzulApi.Models.HorizonteAzul;
using HorizonteAzulApi.Resources;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HorizonteAzulApi.Domain.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly string _jwtKey;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException(StringResources.JwtKeyNaoConfigurado);
        }

        public string GenerateToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "user.Email"),
                new Claim(ClaimTypes.NameIdentifier, "user.Id.ToString()"),
                new Claim(ClaimTypes.Role, "getUserType(user.UserType)")
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
