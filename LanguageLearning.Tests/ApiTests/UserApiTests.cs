using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class UserApiTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public UserApiTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUserById_ReturnsUser()
    {
        var response = await _client.GetAsync("/api/user/1");
        response.EnsureSuccessStatusCode();

        var user = await response.Content.ReadFromJsonAsync<object>();
        Assert.NotNull(user);
    }
}
