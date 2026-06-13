using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        Customer? GetCustomerById(int customerId);
    }
}