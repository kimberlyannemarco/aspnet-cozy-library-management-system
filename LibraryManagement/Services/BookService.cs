using LibraryManagement.Models;
using LibraryManagement.Data;
using LibraryManagement.ViewModels;
using LibraryManagement.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Services
{
public class BookService : IBookService
{
private readonly LibraryContext _context;


public BookService(LibraryContext context)
{
_context = context;
}


// 1. CreateBook – move your POST Create logic here
public void CreateBook(Book book)
{
if (book.Title == null ||
book.ISBN == null ||
book.PublicationYear == 0 ||
book.AuthorId == 0 ||
book.LibraryBranchId == 0)
{
throw new InvalidBookException("Required fields are missing.");
}


_context.Books.Add(book);
_context.SaveChanges();
}


// 2. GetBookWithDetails – move your Details logic here
public BookViewModel GetBookWithDetails(int bookId)
{
var book = _context.Books
.Include(b => b.Author)
.Include(b => b.LibraryBranch)
.Include(b => b.BookRatings)
.FirstOrDefault(b => b.BookId == bookId);


if (book == null)
{
throw new BookNotFoundException(bookId);
}


var ratings = book.BookRatings ?? new List<BookRating>();
var averageRating = ratings.Any() ? ratings.Average(r => r.Rating) : 0.0;


return new BookViewModel
{
Book = book,
AverageRating = averageRating,
Ratings = ratings.ToList()
};
}


// 3. RateBook – move your POST Rate logic here
public void RateBook(int bookId, int rating, string? comment)
{
var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
if (book == null)
{
throw new BookNotFoundException(bookId);
}


var newRating = new BookRating
{
BookId = bookId,
Rating = rating,
Comment = comment ?? "No comment"
};


_context.BookRatings.Add(newRating);
_context.SaveChanges();
}
}


// You can add this if you don’t have it yet:
public class InvalidBookException : Exception
{
public InvalidBookException(string message) : base(message) { }
}
}