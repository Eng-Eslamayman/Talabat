using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Talabat.BusinessLayer.Interfaces;
using Talabat.DataLayer.Models;

namespace Talabat.BusinessLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(Customer user)
        {
            var claims = new List<Claim> { new Claim("id", user.Id.ToString()) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
