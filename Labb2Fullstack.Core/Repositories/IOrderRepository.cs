using Labb2Fullstack.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}