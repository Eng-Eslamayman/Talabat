using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.DataLayer.Database;
using Talabat.DataLayer.Interfaces;
using Talabat.DataLayer.Models;

namespace Talabat.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByUsernameAsync(string username)
            => await _context.Customers.FirstOrDefaultAsync(x => x.Username == username);

        public async Task AddAsync(Customer? customer) => await _context.Customers.AddAsync(customer);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}
