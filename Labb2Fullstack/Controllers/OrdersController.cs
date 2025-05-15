using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Labb2Fullstack.Core.Models;
using Labb2Fullstack.Core.Repositories;
using Labb2Fullstack.Core.DTO;

namespace Labb2Fullstack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

       [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validOrderItems = model.OrderItems
                            .Where(oi => oi.Quantity > 0 && oi.ProductId > 0)
                            .ToList();

            if (!validOrderItems.Any())
            {
                return BadRequest("Inga produkter har valts.");
            }

            var newOrder = new Order
            {
                CustomerId = model.CustomerId,
                OrderDatum = model.OrderDatum,
                OrderItems = validOrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Antal = oi.Quantity
                }).ToList()
            };

            await _orderRepository.AddOrderAsync(newOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
                return BadRequest("Order-ID stämmer inte överens.");

            await _orderRepository.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
