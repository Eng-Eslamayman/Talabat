using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Talabat.Database;
using Talabat.BusinessLayer.DTOs;
using Talabat.BusinessLayer.Interfaces;

namespace Talabat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private int GetUserId() => int.Parse(User.FindFirst("id")?.Value ?? "0");

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _orderService.GetAllOrdersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var customerId = GetUserId();
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            var customerId = GetUserId();
            var order = await _orderService.CreateOrderAsync(dto, customerId);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customerId = GetUserId();
            var result = await _orderService.DeleteOrderAsync(id, customerId);
            return result ? Ok("Deleted") : Unauthorized();
        }
    }

}
