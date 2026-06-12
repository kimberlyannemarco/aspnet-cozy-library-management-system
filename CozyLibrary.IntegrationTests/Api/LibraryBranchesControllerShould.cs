using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LibraryManagement.Models;
using Xunit;

namespace CozyLibrary.IntegrationTests.Api;

public class LibraryBranchesControllerShould : IClassFixture<TestWebAppFactory>
{
    private readonly HttpClient _client;

    public LibraryBranchesControllerShould(TestWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetLibraryBranches_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/librarybranches");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var branches = await response.Content.ReadFromJsonAsync<List<LibraryBranch>>();
        branches.Should().NotBeNull();
        branches!.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetLibraryBranch_ExistingId_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/librarybranches/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var branch = await response.Content.ReadFromJsonAsync<LibraryBranch>();
        branch.Should().NotBeNull();
        branch!.LibraryBranchId.Should().Be(1);
    }

    [Fact]
    public async Task GetLibraryBranch_MissingId_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/librarybranches/99999");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateLibraryBranch_ValidBranch_ShouldReturnCreated()
    {
        var newBranch = new LibraryBranch
        {
            BranchName = "Test Branch",
            BranchAddress = "123 Test St"
        };

        var response = await _client.PostAsJsonAsync("/api/librarybranches", newBranch);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var created = await response.Content.ReadFromJsonAsync<LibraryBranch>();
        created.Should().NotBeNull();
        created!.LibraryBranchId.Should().BeGreaterThan(0);
        created.BranchName.Should().Be("Test Branch");
    }

    [Fact]
    public async Task UpdateLibraryBranch_ValidBranch_ShouldReturnNoContent()
    {
        var updateBranch = new LibraryBranch
        {
            LibraryBranchId = 1,
            BranchName = "Updated Branch",
            BranchAddress = "Updated Address"
        };

        var response = await _client.PutAsJsonAsync("/api/librarybranches/1", updateBranch);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteLibraryBranch_ExistingId_ShouldReturnNoContent()
    {
        var response = await _client.DeleteAsync("/api/librarybranches/2");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}