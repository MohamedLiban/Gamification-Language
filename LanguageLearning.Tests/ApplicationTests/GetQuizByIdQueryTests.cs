using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Features.Queries.Quiz;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using Xunit;

public class GetQuizByIdQueryTests
{
    private readonly IQuizRepository _quizRepository;
    private readonly GetQuizByIdQueryHandler _handler;

    public GetQuizByIdQueryTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
        _handler = new GetQuizByIdQueryHandler(_quizRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnQuiz()
    {
        var quiz = new Quiz { Id = 1, Title = "Sample Quiz" };
        A.CallTo(() => _quizRepository.GetByIdAsync(1)).Returns(quiz);

        var result = await _handler.Handle(new GetQuizByIdQuery(1), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("Sample Quiz", result.Title);
    }
}
