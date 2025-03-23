using Talabat.DataLayer.Models;

namespace Talabat.BusinessLayer.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Customer user);
    }
}
