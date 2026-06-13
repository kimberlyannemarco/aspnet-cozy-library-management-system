using System;
using System.Runtime.Serialization;

namespace LibraryManagement.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; }

        public CustomerNotFoundException(int customerId)
            : base($"Customer with ID {customerId} was not found in the library.")
        {
            CustomerId = customerId;
        }
    }
}