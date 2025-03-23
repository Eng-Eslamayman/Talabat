using Microsoft.EntityFrameworkCore;
using Talabat.DataLayer.Interfaces;
using Talabat.DataLayer.Models;

namespace Talabat.DataLayer.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task<Order?> GetByIdAsync(int id)
        => await _context.Orders.FindAsync(id);

    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId)
        => await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();

    public async Task AddAsync(Order order)
        => await _context.Orders.AddAsync(order);

    public async Task DeleteAsync(Order order)
        => _context.Orders.Remove(order);

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}