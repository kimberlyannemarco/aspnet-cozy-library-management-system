using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CozyLibrary.UnitTests.Services
{
    public class AuthorServiceShould
    {
        private readonly Mock<LibraryContext> _mockContext;
        private readonly Mock<DbSet<Author>> _mockAuthors;
        private readonly AuthorService _service;

        public AuthorServiceShould()
        {
            var authorsData = new List<Author>().AsQueryable();

            _mockAuthors = new Mock<DbSet<Author>>();
            _mockAuthors.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(authorsData.Provider);
            _mockAuthors.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(authorsData.Expression);
            _mockAuthors.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(authorsData.ElementType);
            _mockAuthors.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(authorsData.GetEnumerator());

            _mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            _mockContext.Setup(c => c.Authors).Returns(_mockAuthors.Object);

            _service = new AuthorService(_mockContext.Object);
        }

        /****************************************************************************
         * CREATE tests
         ****************************************************************************/

        [Fact]
        public void CreateAuthor_WithValidAuthor_ShouldAddToContextAndSave()
        {
            var author = new Author
            {
                AuthorId = 1,
                FirstName = "Jane",
                LastName = "Doe",
                BirthYear = 1970,
                BooksPublished = 0
            };

            _service.CreateAuthor(author);

            _mockAuthors.Verify(m => m.Add(author), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CreateAuthor_WithNullAuthor_ShouldThrowInvalidAuthorException()
        {
            Assert.Throws<InvalidAuthorException>(() => _service.CreateAuthor(null!));
        }

        [Fact]
        public void CreateAuthor_WithMissingFirstName_ShouldThrowInvalidAuthorException()
        {
            var author = new Author
            {
                AuthorId = 1,
                FirstName = null,
                LastName = "Doe"
            };

            Assert.Throws<InvalidAuthorException>(() => _service.CreateAuthor(author));
        }

        [Fact]
        public void CreateAuthor_WithMissingLastName_ShouldThrowInvalidAuthorException()
        {
            var author = new Author
            {
                AuthorId = 1,
                FirstName = "Jane",
                LastName = null
            };

            Assert.Throws<InvalidAuthorException>(() => _service.CreateAuthor(author));
        }

        /****************************************************************************
         * GET / GetAuthorById tests
         ****************************************************************************/

        [Fact]
        public void GetAuthorById_WithExistingAuthor_ShouldReturnAuthor()
        {
            var author = new Author
            {
                AuthorId = 1,
                FirstName = "Jane",
                LastName = "Doe",
                BirthYear = 1970,
                BooksPublished = 5,
                Books = new List<Book>()
            };

            var authors = new List<Author> { author }.AsQueryable();

            var mockAuthors = new Mock<DbSet<Author>>();
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(authors.Provider);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(authors.Expression);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(authors.ElementType);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(authors.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Authors).Returns(mockAuthors.Object);

            var service = new AuthorService(mockContext.Object);

            var result = service.GetAuthorById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.AuthorId);
            Assert.Equal("Jane", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        [Fact]
        public void GetAuthorById_WithMissingAuthorId_ShouldThrowAuthorNotFoundException()
        {
            var authors = new List<Author>().AsQueryable();

            var mockAuthors = new Mock<DbSet<Author>>();
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(authors.Provider);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(authors.Expression);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(authors.ElementType);
            mockAuthors.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(authors.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.Authors).Returns(mockAuthors.Object);

            var service = new AuthorService(mockContext.Object);

            Assert.Throws<AuthorNotFoundException>(() => service.GetAuthorById(999));
        }
    }
}