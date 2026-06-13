// Book.cs
namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
    public class Book
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public LibraryBranch LibraryBranch { get; set; }
        public int LibraryBranchId { get; set; }
        public List<BookRating> BookRatings { get; set; } = new();
        
    }