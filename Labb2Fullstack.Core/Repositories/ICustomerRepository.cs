using System.Collections.Generic;
using System.Threading.Tasks;
using Labb2Fullstack.Core.Models;

namespace Labb2Fullstack.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> SearchCustomersByEmailAsync(string email);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}