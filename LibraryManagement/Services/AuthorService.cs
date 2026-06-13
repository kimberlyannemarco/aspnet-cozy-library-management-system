using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Services
{
public class AuthorService : IAuthorService
{
private readonly LibraryContext _context;


public AuthorService(LibraryContext context)
{
_context = context;
}


public void CreateAuthor(Author author)
{
if (author == null)
{
throw new InvalidAuthorException("Author cannot be null.");
}


if (string.IsNullOrEmpty(author.FirstName) ||
string.IsNullOrEmpty(author.LastName))
{
throw new InvalidAuthorException("First name and last name are required.");
}


_context.Authors.Add(author);
_context.SaveChanges();
}


public Author? GetAuthorById(int authorId)
{
var author = _context.Authors
.Include(a => a.Books)
.FirstOrDefault(a => a.AuthorId == authorId);


if (author == null)
{
throw new AuthorNotFoundException(authorId);
}


return author;
}
}


public class InvalidAuthorException : Exception
{
public InvalidAuthorException(string message) : base(message) { }
}
}