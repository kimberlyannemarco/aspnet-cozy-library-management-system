using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        // Create a new book
        void CreateBook(Book book);

        // Get a book with details (Author, LibraryBranch, ratings)
        BookViewModel GetBookWithDetails(int bookId);

        // Rate a book
        void RateBook(int bookId, int rating, string? comment);
    }
}