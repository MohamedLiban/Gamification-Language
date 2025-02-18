using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Features.Commands.CreateCommands;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using Xunit;

public class CreateQuizCommandTests
{
    private readonly IQuizRepository _quizRepository;
    private readonly CreateQuizCommandHandler _handler;

    public CreateQuizCommandTests()
    {
        _quizRepository = A.Fake<IQuizRepository>();
        _handler = new CreateQuizCommandHandler(_quizRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnQuizId()
    {
        var command = new CreateQuizCommand { Title = "Test Quiz", DifficultyLevel = 1 };
        A.CallTo(() => _quizRepository.AddAsync(A<Quiz>._)).Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result > 0);
    }
}
