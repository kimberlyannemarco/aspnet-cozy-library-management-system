using System.Net;
using System.Net.Http.Json;
using LibraryManagement.Models;
using FluentAssertions;
using Xunit;

namespace CozyLibrary.IntegrationTests.Api;

public class BooksControllerShould : IClassFixture<TestWebAppFactory>
{
    private readonly HttpClient _client;

    public BooksControllerShould(TestWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBooks_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/Books");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var books = await response.Content.ReadFromJsonAsync<List<Book>>();
        books.Should().NotBeNull();
        books!.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetBook_ExistingId_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/books/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var book = await response.Content.ReadFromJsonAsync<Book>();
        book.Should().NotBeNull();
        book!.BookId.Should().Be(1);
    }

    [Fact]
    public async Task GetBook_MissingId_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/books/99999");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateBook_ValidBook_ShouldReturnCreated()
    {
        var newBook = new Book
        {
            Title = "Test Driven Development",
            ISBN = "123-TEST-ISBN",
            PublicationYear = 2026,
            AuthorId = 1,
            LibraryBranchId = 1
        };

        var response = await _client.PostAsJsonAsync("/api/books", newBook);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var created = await response.Content.ReadFromJsonAsync<Book>();
        created.Should().NotBeNull();
        created!.BookId.Should().BeGreaterThan(0);
        created.Title.Should().Be("Test Driven Development");
    }

    [Fact]
    public async Task UpdateBook_ValidBook_ShouldReturnNoContent()
    {
        var updateBook = new Book
        {
            BookId = 1,
            Title = "The Book Thief - Updated",
            ISBN = "978-1784162122",
            PublicationYear = 2005,
            AuthorId = 4,
            LibraryBranchId = 1
        };

        var response = await _client.PutAsJsonAsync("/api/books/1", updateBook);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteBook_ExistingId_ShouldReturnNoContent()
    {
        var response = await _client.DeleteAsync("/api/books/2");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}