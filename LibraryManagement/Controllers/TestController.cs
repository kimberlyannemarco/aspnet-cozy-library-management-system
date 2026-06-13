using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Exceptions;  // Your custom exceptions

namespace LibraryManagement.Controllers
{
    public class TestController : Controller
    {
        // Generic exception (tests GeneralError case)
        public IActionResult TestException()
        {
            throw new InvalidOperationException("Demo of global exception handling");
        }

        public IActionResult TestBookNotFound()
        {
            throw new BookNotFoundException(999);  // Tests BookNotFound case
        }

        public IActionResult TestAuthorNotFound()
        {
            throw new AuthorNotFoundException(999);  // Tests BookNotFound case
        }

        public IActionResult TestDatabaseDown()
        {
            throw new DatabaseUnavailableException();  // Tests DatabaseDown case
        }
    }
}
