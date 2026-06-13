// BookRating.cs
namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
    public class BookRating
    {    
    [Key]
    public int RatingId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Book Book { get; set; }
    public int BookId { get; set; }
        
    }