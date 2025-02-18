using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Infrastructure.Repositories;
using Xunit;

public class UserRepositoryTests
{
    private readonly IUserRepository _userRepository;

    public UserRepositoryTests()
    {
        _userRepository = A.Fake<IUserRepository>();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser()
    {
        var user = new User { Id = 1, Email = "test@example.com" };
        A.CallTo(() => _userRepository.GetByIdAsync(1)).Returns(user);

        var result = await _userRepository.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("test@example.com", result.Email);
    }
}
