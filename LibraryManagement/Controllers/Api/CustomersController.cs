using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public CustomersController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            // Remove any navigation property validation if needed
            if (customer.CustomerFirstName != null && customer.CustomerLastName != null && 
                customer.CustomerEmail != null && customer.CustomerPhone != null)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
            }
            return BadRequest("Invalid customer data");
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId) return BadRequest("Customer ID mismatch.");

            var existing = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (existing == null) return NotFound();

            existing.CustomerFirstName = customer.CustomerFirstName;
            existing.CustomerLastName = customer.CustomerLastName;
            existing.CustomerEmail = customer.CustomerEmail;
            existing.CustomerPhone = customer.CustomerPhone;
            existing.AcctOpenDate = customer.AcctOpenDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}