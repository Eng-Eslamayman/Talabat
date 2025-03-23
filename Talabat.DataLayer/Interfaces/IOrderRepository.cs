using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DataLayer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Talabat.DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(Order order);
        Task DeleteAsync(Order order);
        Task SaveAsync();
    }

}
