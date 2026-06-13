using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly LibraryContext _context;

        public CustomerService(LibraryContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidCustomerException("Customer cannot be null.");
            }

            if (string.IsNullOrEmpty(customer.CustomerFirstName) ||
                string.IsNullOrEmpty(customer.CustomerLastName) ||
                string.IsNullOrEmpty(customer.CustomerEmail))
            {
                throw new InvalidCustomerException("First name, last name, and email are required.");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer? GetCustomerById(int customerId)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                throw new CustomerNotFoundException(customerId);
            }

            return customer;
        }
    }

    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string message) : base(message) { }
    }
}