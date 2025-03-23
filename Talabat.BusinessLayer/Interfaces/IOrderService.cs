using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BusinessLayer.DTOs;
using Talabat.DataLayer.Models;

namespace Talabat.BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId);
        Task<Order> CreateOrderAsync(OrderDto dto, int customerId);
        Task<bool> DeleteOrderAsync(int orderId, int customerId);
    }
}
