using Microsoft.AspNetCore.Mvc;
using Labb2Fullstack.Core;
using System.Threading.Tasks;
using Labb2Fullstack.Core.Models;
using Labb2Fullstack.Core.Repositories;

namespace Labb2Fullstack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return Ok(customers);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        
        [HttpGet("search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] string email)
        {
            var customers = await _customerRepository.SearchCustomersByEmailAsync(email);
            return Ok(customers);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerRepository.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest("Kund-ID stämmer inte överens.");

            await _customerRepository.UpdateCustomerAsync(customer);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
