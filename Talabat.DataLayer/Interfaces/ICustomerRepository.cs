using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DataLayer.Models;

namespace Talabat.DataLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByUsernameAsync(string username);
        Task AddAsync(Customer? customer);
        Task SaveAsync();
    }

}
