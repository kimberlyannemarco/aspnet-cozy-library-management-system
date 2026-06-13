using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly LibraryContext _context;

        public CustomerController(LibraryContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // Details
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer.CustomerFirstName == null || customer.CustomerLastName == null || customer.CustomerEmail == null || customer.CustomerPhone == null)
            {
                return View(customer);
            }

            customer.AcctOpenDate = DateTime.Now.ToString("MMM dd, yyyy");

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId) return NotFound();
            
            var existing = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (existing != null)
            {
                existing.CustomerFirstName = customer.CustomerFirstName;
                existing.CustomerLastName = customer.CustomerLastName;
                existing.CustomerEmail = customer.CustomerEmail;
                existing.CustomerPhone = customer.CustomerPhone;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    
        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
