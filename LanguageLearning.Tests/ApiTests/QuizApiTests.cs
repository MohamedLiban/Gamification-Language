using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class QuizApiTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public QuizApiTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllQuizzes_ReturnsList()
    {
        var response = await _client.GetAsync("/api/quiz/all");
        response.EnsureSuccessStatusCode();

        var quizzes = await response.Content.ReadFromJsonAsync<List<object>>();
        Assert.NotNull(quizzes);
    }
}
