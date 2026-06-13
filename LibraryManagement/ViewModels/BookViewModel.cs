// BookViewModel.cs
using LibraryManagement.Models;

namespace LibraryManagement.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; } = null!;
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public LibraryBranch LibraryBranch { get; set; }
        public int LibraryBranchId { get; set; }
        public string BranchName { get; set; }
        public double AverageRating { get; set; }
        public List<BookRating> Ratings { get; set; } = new();
        
    }
}
