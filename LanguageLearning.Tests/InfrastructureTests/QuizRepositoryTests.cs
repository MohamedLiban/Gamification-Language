using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Infrastructure.Repositories;
using Xunit;

public class QuizRepositoryTests
{
    private readonly IQuizRepository _quizRepository;

    public QuizRepositoryTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnQuiz()
    {
        var quiz = new Quiz { Id = 1, Title = "Sample Quiz" };
        A.CallTo(() => _quizRepository.GetByIdAsync(1)).Returns(quiz);

        var result = await _quizRepository.GetByIdAsync(1);

        Assert.Equal("Sample Quiz", result.Title);
    }
}
