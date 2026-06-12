using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LibraryManagement.Models;
using Xunit;

namespace CozyLibrary.IntegrationTests.Api;

public class CustomersControllerShould : IClassFixture<TestWebAppFactory>
{
    private readonly HttpClient _client;

    public CustomersControllerShould(TestWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCustomers_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/customers");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var customers = await response.Content.ReadFromJsonAsync<List<Customer>>();
        customers.Should().NotBeNull();
        customers!.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetCustomer_ExistingId_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/customers/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var customer = await response.Content.ReadFromJsonAsync<Customer>();
        customer.Should().NotBeNull();
        customer!.CustomerId.Should().Be(1);
    }

    [Fact]
    public async Task GetCustomer_MissingId_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/customers/99999");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateCustomer_ValidCustomer_ShouldReturnCreated()
    {
        var newCustomer = new Customer
        {
            CustomerFirstName = "Test",
            CustomerLastName = "User",
            CustomerEmail = "test.user@email.com",
            CustomerPhone = "604-555-0101",
            AcctOpenDate = "Apr 22, 2026"
        };

        var response = await _client.PostAsJsonAsync("/api/customers", newCustomer);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var created = await response.Content.ReadFromJsonAsync<Customer>();
        created.Should().NotBeNull();
        created!.CustomerId.Should().BeGreaterThan(0);
        created.CustomerEmail.Should().Be("test.user@email.com");
    }

    [Fact]
    public async Task UpdateCustomer_ValidCustomer_ShouldReturnNoContent()
    {
        var updateCustomer = new Customer
        {
            CustomerId = 1,
            CustomerFirstName = "Updated",
            CustomerLastName = "Name",
            CustomerEmail = "updated@email.com",
            CustomerPhone = "604-555-9999",
            AcctOpenDate = "Jan 1, 2025"
        };

        var response = await _client.PutAsJsonAsync("/api/customers/1", updateCustomer);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteCustomer_ExistingId_ShouldReturnNoContent()
    {
        var response = await _client.DeleteAsync("/api/customers/2");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}