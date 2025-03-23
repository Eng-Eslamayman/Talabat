using System.Security.Cryptography;
using System.Text;
using Talabat.BusinessLayer.DTOs;
using Talabat.BusinessLayer.Interfaces;
using Talabat.DataLayer.Interfaces;
using Talabat.DataLayer.Models;

namespace Talabat.BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly ITokenService _tokenService;

        public AuthService(ICustomerRepository customerRepo, ITokenService tokenService)
        {
            _customerRepo = customerRepo;
            _tokenService = tokenService;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var existing = await _customerRepo.GetByUsernameAsync(dto.Username);
            if (existing != null) return false;

            using var hmac = new HMACSHA512();
            var customer = new Customer
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            await _customerRepo.AddAsync(customer);
            await _customerRepo.SaveAsync();
            return true;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _customerRepo.GetByUsernameAsync(dto.Username);
            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            if (!computed.SequenceEqual(user.PasswordHash)) return null;

            return _tokenService.CreateToken(user);
        }
    }
}
