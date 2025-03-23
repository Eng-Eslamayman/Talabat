using Talabat.BusinessLayer.DTOs;

namespace Talabat.BusinessLayer.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
