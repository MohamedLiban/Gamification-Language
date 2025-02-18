using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Features.Commands.DeleteCommands;
using LanguageLearning.Application.Interfaces;
using Xunit;

public class DeleteQuizCommandTests
{
    private readonly IQuizRepository _quizRepository;
    private readonly DeleteQuizCommandHandler _handler;

    public DeleteQuizCommandTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
        _handler = new DeleteQuizCommandHandler(_quizRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnTrue_WhenQuizDeleted()
    {
        A.CallTo(() => _quizRepository.DeleteAsync(A<int>._)).Returns(Task.CompletedTask);

        var result = await _handler.Handle(new DeleteQuizCommand { Id = 1 }, CancellationToken.None);

        Assert.True(result);
    }
}
