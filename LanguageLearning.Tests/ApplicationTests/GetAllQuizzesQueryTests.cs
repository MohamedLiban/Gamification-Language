using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Features.Queries.Quiz;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using Xunit;

public class GetAllQuizzesQueryTests
{
    private readonly IQuizRepository _quizRepository;
    private readonly GetAllQuizzesQueryHandler _handler;

    public GetAllQuizzesQueryTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
        _handler = new GetAllQuizzesQueryHandler(_quizRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnListOfQuizzes()
    {
        var quizzes = new List<Quiz> { new Quiz { Id = 1, Title = "Test Quiz" } };
        A.CallTo(() => _quizRepository.GetAllAsync()).Returns(quizzes);

        var result = await _handler.Handle(new GetAllQuizzesQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Single(result);
    }
}
