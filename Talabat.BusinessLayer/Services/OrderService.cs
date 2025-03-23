using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BusinessLayer.DTOs;
using Talabat.BusinessLayer.Interfaces;
using Talabat.DataLayer.Interfaces;
using Talabat.DataLayer.Models;

namespace Talabat.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
            => await _orderRepository.GetAllAsync();

        public async Task<Order?> GetOrderByIdAsync(int id)
            => await _orderRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId)
            => await _orderRepository.GetByCustomerIdAsync(customerId);

        public async Task<Order> CreateOrderAsync(OrderDto dto, int customerId)
        {
            var order = new Order
            {
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();

            return order;
        }

        public async Task<bool> DeleteOrderAsync(int orderId, int customerId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null || order.CustomerId != customerId)
                return false;

            await _orderRepository.DeleteAsync(order);
            await _orderRepository.SaveAsync();

            return true;
        }
    }
}
