using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LibraryManagement.Models;
using Xunit;

namespace CozyLibrary.IntegrationTests.Api;

public class AuthorsControllerShould : IClassFixture<TestWebAppFactory>
{
    private readonly HttpClient _client;

    public AuthorsControllerShould(TestWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAuthors_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/authors");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var authors = await response.Content.ReadFromJsonAsync<List<Author>>();
        authors.Should().NotBeNull();
        authors!.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAuthor_ExistingId_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/authors/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var author = await response.Content.ReadFromJsonAsync<Author>();
        author.Should().NotBeNull();
        author!.AuthorId.Should().Be(1);
    }

    [Fact]
    public async Task GetAuthor_MissingId_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/authors/99999");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateAuthor_ValidAuthor_ShouldReturnCreated()
    {
        var newAuthor = new Author
        {
            FirstName = "Test",
            LastName = "Author",
            BirthYear = 1990,
            BooksPublished = 1
        };

        var response = await _client.PostAsJsonAsync("/api/authors", newAuthor);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var created = await response.Content.ReadFromJsonAsync<Author>();
        created.Should().NotBeNull();
        created!.AuthorId.Should().BeGreaterThan(0);
        created.FirstName.Should().Be("Test");
    }

    [Fact]
    public async Task UpdateAuthor_ValidAuthor_ShouldReturnNoContent()
    {
        var updateAuthor = new Author
        {
            AuthorId = 1,
            FirstName = "Updated",
            LastName = "Author",
            BirthYear = 1978,
            BooksPublished = 4
        };

        var response = await _client.PutAsJsonAsync("/api/authors/1", updateAuthor);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAuthor_ExistingId_ShouldReturnNoContent()
    {
        var response = await _client.DeleteAsync("/api/authors/2");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}