using Microsoft.EntityFrameworkCore;
using Talabat.DataLayer.Models;

namespace Talabat.DataLayer.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
