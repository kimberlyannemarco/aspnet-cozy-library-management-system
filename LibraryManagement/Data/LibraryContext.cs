// added Identity Framework Core
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    // switched from
    // public class LibraryContext : DbContext
    // to
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LibraryBranch> LibraryBranches { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);

            // 20 authors
            modelBuilder.Entity<Author>().HasData(
                new Author {AuthorId = 1, FirstName = "Madeline", LastName = "Miller", BirthYear = 1978, BooksPublished = 3 },
                new Author {AuthorId = 2, FirstName = "Shelby", LastName = "Van Pelt", BirthYear = 1980, BooksPublished = 1 },
                new Author {AuthorId = 3, FirstName = "Margaret", LastName = "Atwood", BirthYear = 1939, BooksPublished = 66 },
                new Author {AuthorId = 4, FirstName = "Markus", LastName = "Zusak", BirthYear = 1975, BooksPublished = 7 },
                new Author {AuthorId = 5, FirstName = "Taylor Jenkins", LastName = "Reid", BirthYear = 1983, BooksPublished = 9 },
                new Author {AuthorId = 6, FirstName = "T.J.", LastName = "Klune", BirthYear = 1971, BooksPublished = 34 },
                new Author {AuthorId = 7, FirstName = "Gillian", LastName = "Flynn", BirthYear = 1990, BooksPublished = 3 },
                new Author {AuthorId = 8, FirstName = "R.F.", LastName = "Kuang", BirthYear = 1996, BooksPublished = 6 },
                new Author {AuthorId = 9, FirstName = "David", LastName = "Levithan", BirthYear = 1972, BooksPublished = 30 },
                new Author {AuthorId = 10, FirstName = "Antoine", LastName = "de Saint-Exupery", BirthYear = 1900, BooksPublished = 7 },
                new Author {AuthorId = 11, FirstName = "Stephen", LastName = "Chbosky", BirthYear = 1970, BooksPublished = 2 },
                new Author {AuthorId = 12, FirstName = "Lois", LastName = "Lowry", BirthYear = 1937, BooksPublished = 40 },
                new Author {AuthorId = 13, FirstName = "Alex", LastName = "Michaelides", BirthYear = 1977, BooksPublished = 3 },
                new Author {AuthorId = 14, FirstName = "Morgan", LastName = "Housel", BirthYear = 1984, BooksPublished = 3 },
                new Author {AuthorId = 15, FirstName = "Khaled", LastName = "Hosseini", BirthYear = 1965, BooksPublished = 4 },
                new Author {AuthorId = 16, FirstName = "Kathryn", LastName = "Stockett", BirthYear = 1969, BooksPublished = 1 },
                new Author {AuthorId = 17, FirstName = "Jason", LastName = "Rekulak", BooksPublished = 3 },
                new Author {AuthorId = 18, FirstName = "Rebecca", LastName = "Yarros", BirthYear = 1981, BooksPublished = 26 },
                new Author {AuthorId = 19, FirstName = "Agatha", LastName = "Christie", BirthYear = 1890, BooksPublished = 80 },
                new Author {AuthorId = 20, FirstName = "Colleen", LastName = "Hoover", BirthYear = 1979, BooksPublished = 26 }
            );

            // 20 books
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "The Book Thief", ISBN = "978-1784162122", AuthorId = 4, LibraryBranchId = 1, PublicationYear = 2005 },
                new Book { BookId = 2, Title = "The Seven Husbands of Evelyn Hugo", ISBN = "978-1501161933", AuthorId = 5, LibraryBranchId = 1, PublicationYear = 2017 },
                new Book { BookId = 3, Title = "The House in the Cerulean Sea", ISBN = "978-1250217318", AuthorId = 6, LibraryBranchId = 1, PublicationYear = 2020 },
                new Book { BookId = 4, Title = "Gone Girl", ISBN = "978-3596188789", AuthorId = 7, LibraryBranchId = 1, PublicationYear = 2012 },
                new Book { BookId = 5, Title = "Babel", ISBN = "978-0008501853", AuthorId = 8, LibraryBranchId = 1, PublicationYear = 2022 },
                new Book { BookId = 6, Title = "Circe", ISBN = "978-1408890042", AuthorId = 1, LibraryBranchId = 1, PublicationYear = 2018 },
                new Book { BookId = 7, Title = "Remarkably Bright Creatures", ISBN = "978-0063254480", AuthorId = 2, LibraryBranchId = 1, PublicationYear = 2022 },
                new Book { BookId = 8, Title = "The Handmaid's Tale", ISBN = "978-0771008795", AuthorId = 3, LibraryBranchId = 1, PublicationYear = 1985 },
                new Book { BookId = 9, Title = "Every Day", ISBN = "978-0307931894", AuthorId = 9, LibraryBranchId = 1, PublicationYear = 2012 },
                new Book { BookId = 10, Title = "The Little Prince", ISBN = "978-3140464079", AuthorId = 10, LibraryBranchId = 1, PublicationYear = 1943 },
                new Book { BookId = 11, Title = "The Perks of Being a Wallflower", ISBN = "978-1847394071", AuthorId = 11, LibraryBranchId = 1, PublicationYear = 1999 },
                new Book { BookId = 12, Title = "The Giver", ISBN = "978-0440237686", AuthorId = 12, LibraryBranchId = 1, PublicationYear = 1993 },
                new Book { BookId = 13, Title = "The Silent Patient", ISBN = "978-1250301703", AuthorId = 13, LibraryBranchId = 1, PublicationYear = 2019 },
                new Book { BookId = 14, Title = "The Psychology of Money", ISBN = "978-0857197689", AuthorId = 14, LibraryBranchId = 1, PublicationYear = 2020 },
                new Book { BookId = 15, Title = "A Thousand Splendid Suns", ISBN = "978-0670064915", AuthorId = 15, LibraryBranchId = 1, PublicationYear = 2007 },
                new Book { BookId = 16, Title = "The Help", ISBN = "978-0399155345", AuthorId = 16, LibraryBranchId = 1, PublicationYear = 2009 },
                new Book { BookId = 17, Title = "Hidden Pictures", ISBN = "978-1250819345", AuthorId = 17, LibraryBranchId = 1, PublicationYear = 2022 },
                new Book { BookId = 18, Title = "Iron Flame", ISBN = "978-1649377579", AuthorId = 18, LibraryBranchId = 1, PublicationYear = 2023 },
                new Book { BookId = 19, Title = "And Then There Were None", ISBN = "978-0008123208", AuthorId = 19, LibraryBranchId = 1, PublicationYear = 1939 },
                new Book { BookId = 20, Title = "Verity", ISBN = "978-1538724736", AuthorId = 20, LibraryBranchId = 2, PublicationYear = 2018 }
            );

            // 20 library branches
            modelBuilder.Entity<LibraryBranch>().HasData(
                new LibraryBranch { LibraryBranchId = 1, BranchName = "Main Branch", BranchAddress = "123 Library St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 2, BranchName = "Downtown Branch", BranchAddress = "456 City Ave, Vancouver" },
                new LibraryBranch { LibraryBranchId = 3, BranchName = "Lower Mainland Branch", BranchAddress = "789 Main Ave, Vancouver" },
                new LibraryBranch { LibraryBranchId = 4, BranchName = "University Branch", BranchAddress = "1107 First St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 5, BranchName = "Civic Branch", BranchAddress = "13755 102 Ave, Vancouver" },
                new LibraryBranch { LibraryBranchId = 6, BranchName = "Provincial Branch", BranchAddress = "231 31st St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 7, BranchName = "City Centre Branch", BranchAddress = "1007 Station Rd, Vancouver" },
                new LibraryBranch { LibraryBranchId = 8, BranchName = "North Branch", BranchAddress = "656 High St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 9, BranchName = "Central Branch", BranchAddress = "7481 Park Ave, Vancouver" },
                new LibraryBranch { LibraryBranchId = 10, BranchName = "South Branch", BranchAddress = "331 View Rd, Vancouver" },
                new LibraryBranch { LibraryBranchId = 11, BranchName = "East Branch", BranchAddress = "9970 Center Street, Vancouver" },
                new LibraryBranch { LibraryBranchId = 12, BranchName = "West Branch", BranchAddress = "385 Queens Rd, Vancouver" },
                new LibraryBranch { LibraryBranchId = 13, BranchName = "Community Branch", BranchAddress = "17552 Green Lane, Vancouver" },
                new LibraryBranch { LibraryBranchId = 14, BranchName = "Regional Branch", BranchAddress = "108 School St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 15, BranchName = "University Branch", BranchAddress = "2219 Elm St, Vancouver" },
                new LibraryBranch { LibraryBranchId = 16, BranchName = "Ridge Branch", BranchAddress = "3441 Victoria Rd, Vancouver" },
                new LibraryBranch { LibraryBranchId = 17, BranchName = "Valley Branch", BranchAddress = "102 Hamilton Heights, Vancouver" },
                new LibraryBranch { LibraryBranchId = 18, BranchName = "Rural Branch", BranchAddress = "389 Maple Ridge, Vancouver" },
                new LibraryBranch { LibraryBranchId = 19, BranchName = "Uptown Branch", BranchAddress = "6273 Sun Valley, Vancouver" },
                new LibraryBranch { LibraryBranchId = 20, BranchName = "First Branch", BranchAddress = "901 Campus Rd, Vancouver" }
            );

            // 20 customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerFirstName = "Maria", CustomerLastName = "Wang", CustomerEmail = "maria.w@email.com", CustomerPhone = "236-356-7381", AcctOpenDate = "Jan 22, 2025" },
                new Customer { CustomerId = 2, CustomerFirstName = "Emma", CustomerLastName = "Li", CustomerEmail = "emma.li@email.com", CustomerPhone = "604-274-9981", AcctOpenDate = "Feb 14, 2025" },
                new Customer { CustomerId = 3, CustomerFirstName = "Fatima", CustomerLastName = "Zhang", CustomerEmail = "fatima.zhang@email.com", CustomerPhone = "234-100-4567", AcctOpenDate = "Feb 25, 2025" },
                new Customer { CustomerId = 4, CustomerFirstName = "Anna", CustomerLastName = "Nguyen", CustomerEmail = "anna.nguyen@email.com", CustomerPhone = "604-123-6607", AcctOpenDate = "Apr 28, 2025" },
                new Customer { CustomerId = 5, CustomerFirstName = "Olivia", CustomerLastName = "Garcia", CustomerEmail = "liv.garcia@email.com", CustomerPhone = "889-678-2231", AcctOpenDate = "May 4, 2025" },
                new Customer { CustomerId = 6, CustomerFirstName = "Sarah", CustomerLastName = "Kumar", CustomerEmail = "sarah.kumar@email.com", CustomerPhone = "604-265-5689", AcctOpenDate = "Jun 3, 2025" },
                new Customer { CustomerId = 7, CustomerFirstName = "Mary", CustomerLastName = "Ali", CustomerEmail = "mary.ali@email.com", CustomerPhone = "604-654-7819", AcctOpenDate = "Jun 7, 2025" },
                new Customer { CustomerId = 8, CustomerFirstName = "Sofia", CustomerLastName = "Smith", CustomerEmail = "sofia.smith@email.com", CustomerPhone = "235-246-0921", AcctOpenDate = "Jul 2, 2025" },
                new Customer { CustomerId = 9, CustomerFirstName = "Elizabeth", CustomerLastName = "Johnson", CustomerEmail = "lizzie.johnson@email.com", CustomerPhone = "604-120-2345", AcctOpenDate = "Jul 9, 2025" },
                new Customer { CustomerId = 10, CustomerFirstName = "Isabella", CustomerLastName = "Williams", CustomerEmail = "issa.williams@email.com", CustomerPhone = "778-099-9876", AcctOpenDate = "Jul 12, 2025" },
                new Customer { CustomerId = 11, CustomerFirstName = "Muhammad", CustomerLastName = "Brown", CustomerEmail = "muhammad.brown@email.com", CustomerPhone = "604-180-1234", AcctOpenDate = "Jul 19, 2025" },
                new Customer { CustomerId = 12, CustomerFirstName = "John", CustomerLastName = "Jones", CustomerEmail = "john.jones@email.com", CustomerPhone = "604-457-0200", AcctOpenDate = "Jul 22, 2025" },
                new Customer { CustomerId = 13, CustomerFirstName = "James", CustomerLastName = "Miller", CustomerEmail = "james.miller@email.com", CustomerPhone = "604-123-2012", AcctOpenDate = "Aug 10, 2025" },
                new Customer { CustomerId = 14, CustomerFirstName = "David", CustomerLastName = "Davis", CustomerEmail = "david.davis@email.com", CustomerPhone = "912-942-8671", AcctOpenDate = "Aug 13, 2025" },
                new Customer { CustomerId = 15, CustomerFirstName = "Ahmed", CustomerLastName = "Rodriguez", CustomerEmail = "ahmed.rodriguez@email.com", CustomerPhone = "604-227-4252", AcctOpenDate = "Oct 25, 2025" },
                new Customer { CustomerId = 16, CustomerFirstName = "Michael", CustomerLastName = "Martinez", CustomerEmail = "mike.martinez@email.com", CustomerPhone = "224-764-7781", AcctOpenDate = "Nov 6, 2025" },
                new Customer { CustomerId = 17, CustomerFirstName = "Ali", CustomerLastName = "Hernandez", CustomerEmail = "ali.hern@email.com", CustomerPhone = "604-246-3453", AcctOpenDate = "Nov 25, 2025" },
                new Customer { CustomerId = 18, CustomerFirstName = "Omar", CustomerLastName = "Gonzalez", CustomerEmail = "omar.gonzi@email.com", CustomerPhone = "887-063-2342", AcctOpenDate = "Dec 1, 2025" },
                new Customer { CustomerId = 19, CustomerFirstName = "Joseph", CustomerLastName = "Mueller", CustomerEmail = "joe.mueller@email.com", CustomerPhone = "604-567-8555", AcctOpenDate = "Dec 28, 2025" },
                new Customer { CustomerId = 20, CustomerFirstName = "Santiago", CustomerLastName = "Silva", CustomerEmail = "santiago.s@email.com", CustomerPhone = "654-890-7843", AcctOpenDate = "Jan 4, 2026" }
            );

            modelBuilder.Entity<BookRating>().HasData(
            new BookRating { RatingId = 1, BookId = 1, Rating = 5, Comment = "Great world-building" },
            new BookRating { RatingId = 2, BookId = 2, Rating = 4, Comment = "Cozy read" }
            );
        }
    }
}
