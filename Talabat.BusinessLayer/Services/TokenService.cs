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
        public string CreateToken(Customer user)
        {
            var claims = new List<Claim> { new Claim("id", user.Id.ToString()) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123!"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
