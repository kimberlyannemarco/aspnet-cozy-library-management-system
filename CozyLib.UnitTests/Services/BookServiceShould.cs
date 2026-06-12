using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Services;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CozyLibrary.UnitTests.Services
{
    public class BookServiceShould
    {
        private readonly Mock<LibraryContext> _mockContext;
        private readonly Mock<DbSet<Book>> _mockBooks;
        private readonly Mock<DbSet<BookRating>> _mockRatings;
        private readonly BookService _service;

        public BookServiceShould()
        {
            var booksData = new List<Book>().AsQueryable();
            var ratingsData = new List<BookRating>().AsQueryable();

            _mockBooks = new Mock<DbSet<Book>>();
            _mockBooks.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(booksData.Provider);
            _mockBooks.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(booksData.Expression);
            _mockBooks.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(booksData.ElementType);
            _mockBooks.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(booksData.GetEnumerator()); // ← was ratingsData here earlier

            _mockRatings = new Mock<DbSet<BookRating>>();
            _mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Provider).Returns(ratingsData.Provider);
            _mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Expression).Returns(ratingsData.Expression);
            _mockRatings.As<IQueryable<BookRating>>().Setup(m => m.ElementType).Returns(ratingsData.ElementType);
            _mockRatings.As<IQueryable<BookRating>>().Setup(m => m.GetEnumerator()).Returns(ratingsData.GetEnumerator());

            _mockContext = new Mock<LibraryContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<LibraryContext>());
            _mockContext.Setup(c => c.Books).Returns(_mockBooks.Object);
            _mockContext.Setup(c => c.BookRatings).Returns(_mockRatings.Object);

            _service = new BookService(_mockContext.Object);
        }

        /****************************************************************************
         * CREATE tests
         ****************************************************************************/

        [Fact]
        public void CreateBook_WithValidBook_ShouldAddToContextAndSave()
        {
            var book = new Book
            {
                Title = "Test Book",
                ISBN = "1234567890",
                PublicationYear = 2025,
                AuthorId = 1,
                LibraryBranchId = 1
            };

            _service.CreateBook(book);

            _mockBooks.Verify(m => m.Add(book), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CreateBook_WithMissingTitle_ShouldThrowInvalidBookException()
        {
            var book = new Book
            {
                Title = null,
                ISBN = "1234567890",
                PublicationYear = 2025,
                AuthorId = 1,
                LibraryBranchId = 1
            };

            Assert.Throws<InvalidBookException>(() => _service.CreateBook(book));
        }

        [Fact]
        public void CreateBook_WithMissingISBN_ShouldThrowInvalidBookException()
        {
            var book = new Book
            {
                Title = "Test Book",
                ISBN = null,
                PublicationYear = 2025,
                AuthorId = 1,
                LibraryBranchId = 1
            };

            Assert.Throws<InvalidBookException>(() => _service.CreateBook(book));
        }

        [Fact]
        public void CreateBook_WithZeroPublicationYear_ShouldThrowInvalidBookException()
        {
            var book = new Book
            {
                Title = "Test Book",
                ISBN = "1234567890",
                PublicationYear = 0,
                AuthorId = 1,
                LibraryBranchId = 1
            };

            Assert.Throws<InvalidBookException>(() => _service.CreateBook(book));
        }

        [Fact]
        public void CreateBook_WithZeroAuthorId_ShouldThrowInvalidBookException()
        {
            var book = new Book
            {
                Title = "Test Book",
                ISBN = "1234567890",
                PublicationYear = 2025,
                AuthorId = 0,
                LibraryBranchId = 1
            };

            Assert.Throws<InvalidBookException>(() => _service.CreateBook(book));
        }

        [Fact]
        public void CreateBook_WithZeroLibraryBranchId_ShouldThrowInvalidBookException()
        {
            var book = new Book
            {
                Title = "Test Book",
                ISBN = "1234567890",
                PublicationYear = 2025,
                AuthorId = 1,
                LibraryBranchId = 0
            };

            Assert.Throws<InvalidBookException>(() => _service.CreateBook(book));
        }

        /****************************************************************************
         * RATE tests
         ****************************************************************************/

        [Fact]
        public void RateBook_WithExistingBook_ShouldAddRatingAndSave()
        {
            var existingBook = new Book { BookId = 1, Title = "Test Book" };
            var bookQuery = new List<Book> { existingBook }.AsQueryable();

            var mockBooks = new Mock<DbSet<Book>>();
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(bookQuery.Provider);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(bookQuery.Expression);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(bookQuery.ElementType);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(bookQuery.GetEnumerator());

            var mockRatings = new Mock<DbSet<BookRating>>();
            var ratingsQuery = new List<BookRating>().AsQueryable();
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Provider).Returns(ratingsQuery.Provider);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Expression).Returns(ratingsQuery.Expression);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.ElementType).Returns(ratingsQuery.ElementType);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.GetEnumerator()).Returns(ratingsQuery.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Books).Returns(mockBooks.Object);
            mockContext.Setup(c => c.BookRatings).Returns(mockRatings.Object);

            var service = new BookService(mockContext.Object);

            service.RateBook(1, 5, "Great book");

            mockRatings.Verify(m => m.Add(It.Is<BookRating>(r =>
                r.BookId == 1 &&
                r.Rating == 5 &&
                r.Comment == "Great book"
            )), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void RateBook_WithNonexistentBookId_ShouldThrowBookNotFoundException()
        {
            var bookQuery = new List<Book>().AsQueryable();

            var mockBooks = new Mock<DbSet<Book>>();
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(bookQuery.Provider);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(bookQuery.Expression);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(bookQuery.ElementType);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(bookQuery.GetEnumerator());

            var mockRatings = new Mock<DbSet<BookRating>>();
            var ratingsQuery = new List<BookRating>().AsQueryable();
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Provider).Returns(ratingsQuery.Provider);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.Expression).Returns(ratingsQuery.Expression);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.ElementType).Returns(ratingsQuery.ElementType);
            mockRatings.As<IQueryable<BookRating>>().Setup(m => m.GetEnumerator()).Returns(ratingsQuery.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Books).Returns(mockBooks.Object);
            mockContext.Setup(c => c.BookRatings).Returns(mockRatings.Object);

            var service = new BookService(mockContext.Object);

            Assert.Throws<BookNotFoundException>(() => service.RateBook(999, 4, "OK"));
        }

        /****************************************************************************
         * DETAILS / GetBookWithDetails tests
         ****************************************************************************/

        [Fact]
        public void GetBookWithDetails_WithValidExistingBook_ShouldReturnViewModel()
        {
            var book = new Book
            {
                BookId = 1,
                Title = "Test Book",
                AuthorId = 1,
                LibraryBranchId = 1,
                BookRatings = new List<BookRating>
                {
                    new BookRating { Rating = 4 },
                    new BookRating { Rating = 5 }
                }
            };

            var bookQuery = new List<Book> { book }.AsQueryable();

            var mockBooks = new Mock<DbSet<Book>>();
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(bookQuery.Provider);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(bookQuery.Expression);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(bookQuery.ElementType);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(bookQuery.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Books).Returns(mockBooks.Object);

            var service = new BookService(mockContext.Object);

            var result = service.GetBookWithDetails(1);

            Assert.Equal(book.BookId, result.Book.BookId);
            Assert.Equal(4.5, result.AverageRating);
            Assert.Equal(2, result.Ratings.Count);
        }

        [Fact]
        public void GetBookWithDetails_WithNoBookFound_ShouldThrowBookNotFoundException()
        {
            var bookQuery = new List<Book>().AsQueryable();

            var mockBooks = new Mock<DbSet<Book>>();
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(bookQuery.Provider);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(bookQuery.Expression);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(bookQuery.ElementType);
            mockBooks.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(bookQuery.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Books).Returns(mockBooks.Object);

            var service = new BookService(mockContext.Object);

            Assert.Throws<BookNotFoundException>(() => service.GetBookWithDetails(1));
        }
    }
}