using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class AuthApiTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthApiTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_ReturnsSuccess()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/register", new { Email = "test@example.com", Password = "Test123!" });
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Login_ReturnsToken()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/login", new { Email = "test@example.com", Password = "Test123!" });
        var result = await response.Content.ReadFromJsonAsync<string>();
        Assert.NotNull(result);
    }
}
