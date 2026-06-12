using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CozyLibrary.UnitTests.Services
{
    public class CustomerServiceShould
    {
        private readonly Mock<LibraryContext> _mockContext;
        private readonly Mock<DbSet<Customer>> _mockCustomers;
        private readonly CustomerService _service;

        public CustomerServiceShould()
        {
            var customersData = new List<Customer>().AsQueryable();

            _mockCustomers = new Mock<DbSet<Customer>>();
            _mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customersData.Provider);
            _mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customersData.Expression);
            _mockCustomers.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customersData.ElementType);
            _mockCustomers.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customersData.GetEnumerator());

            _mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            _mockContext.Setup(c => c.Customers).Returns(_mockCustomers.Object);

            _service = new CustomerService(_mockContext.Object);
        }

        /****************************************************************************
         * CREATE tests
         ****************************************************************************/

        [Fact]
        public void CreateCustomer_WithValidCustomer_ShouldAddToContextAndSave()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "John",
                CustomerLastName = "Smith",
                CustomerEmail = "john@example.com",
                CustomerPhone = "555-1234",
                AcctOpenDate = "2026-04-22"
            };

            _service.CreateCustomer(customer);

            _mockCustomers.Verify(m => m.Add(customer), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CreateCustomer_WithNullCustomer_ShouldThrowInvalidCustomerException()
        {
            Assert.Throws<InvalidCustomerException>(() => _service.CreateCustomer(null!));
        }

        [Fact]
        public void CreateCustomer_WithMissingFirstName_ShouldThrowInvalidCustomerException()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = null,
                CustomerLastName = "Smith",
                CustomerEmail = "john@example.com"
            };

            Assert.Throws<InvalidCustomerException>(() => _service.CreateCustomer(customer));
        }

        [Fact]
        public void CreateCustomer_WithMissingLastName_ShouldThrowInvalidCustomerException()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "John",
                CustomerLastName = null,
                CustomerEmail = "john@example.com"
            };

            Assert.Throws<InvalidCustomerException>(() => _service.CreateCustomer(customer));
        }

        [Fact]
        public void CreateCustomer_WithMissingEmail_ShouldThrowInvalidCustomerException()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "John",
                CustomerLastName = "Smith",
                CustomerEmail = null
            };

            Assert.Throws<InvalidCustomerException>(() => _service.CreateCustomer(customer));
        }

        /****************************************************************************
         * GET / GetCustomerById tests
         ****************************************************************************/

        [Fact]
        public void GetCustomerById_WithExistingCustomer_ShouldReturnCustomer()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "John",
                CustomerLastName = "Smith",
                CustomerEmail = "john@example.com",
                CustomerPhone = "555-1234",
                AcctOpenDate = "2026-04-22"
            };

            var customers = new List<Customer> { customer }.AsQueryable();

            var mockCustomers = new Mock<DbSet<Customer>>();
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Customers).Returns(mockCustomers.Object);

            var service = new CustomerService(mockContext.Object);

            var result = service.GetCustomerById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.CustomerId);
            Assert.Equal("John", result.CustomerFirstName);
            Assert.Equal("Smith", result.CustomerLastName);
            Assert.Equal("john@example.com", result.CustomerEmail);
        }

        [Fact]
        public void GetCustomerById_WithMissingCustomerId_ShouldThrowCustomerNotFoundException()
        {
            var customers = new List<Customer>().AsQueryable();

            var mockCustomers = new Mock<DbSet<Customer>>();
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Customers).Returns(mockCustomers.Object);

            var service = new CustomerService(mockContext.Object);

            Assert.Throws<CustomerNotFoundException>(() => service.GetCustomerById(999));
        }
    }
}