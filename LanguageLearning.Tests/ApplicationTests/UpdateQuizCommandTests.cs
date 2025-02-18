using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Features.Commands.UpdateCommands;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using Xunit;

public class UpdateQuizCommandTests
{
    private readonly IQuizRepository _quizRepository;
    private readonly UpdateQuizCommandHandler _handler;

    public UpdateQuizCommandTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
        _handler = new UpdateQuizCommandHandler(_quizRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnTrue_WhenQuizUpdated()
    {
        var quiz = new Quiz { Id = 1, Title = "Old Title" };
        A.CallTo(() => _quizRepository.GetByIdAsync(1)).Returns(quiz);
        A.CallTo(() => _quizRepository.UpdateAsync(A<Quiz>._)).DoesNothing();

        var result = await _handler.Handle(new UpdateQuizCommand { Id = 1, Title = "New Title" }, CancellationToken.None);

        Assert.True(result);
        Assert.Equal("New Title", quiz.Title);
    }
}
