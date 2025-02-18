using System.Threading.Tasks;
using FakeItEasy;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Infrastructure.Authentication;
using Xunit;

public class AuthServiceTests
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _userRepository = A.Fake<IUserRepository>();
        _passwordHasher = A.Fake<IPasswordHasher>();
        _jwtService = A.Fake<IJwtService>();

        _authService = new AuthService(_userRepository, _passwordHasher, _jwtService);
    }

    [Fact]
    public async Task Register_ShouldReturnToken_WhenUserIsCreated()
    {
        var user = new User { Id = 1, Email = "test@example.com", PasswordHash = "hashedPassword" };
        var password = "Test123!";
        var hashedPassword = "hashedPassword";
        var token = "validToken";

        A.CallTo(() => _userRepository.GetByEmailAsync(user.Email)).Returns(Task.FromResult<User>(null));
        A.CallTo(() => _passwordHasher.HashPassword(password)).Returns(hashedPassword);
        A.CallTo(() => _userRepository.AddAsync(A<User>._)).Returns(Task.CompletedTask);
        A.CallTo(() => _jwtService.GenerateToken(A<User>._)).Returns(token);

        var result = await _authService.Register(user.Email, password);

        Assert.NotNull(result);
        Assert.Equal(token, result);
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenUserExists()
    {
        var user = new User { Id = 1, Email = "test@example.com", PasswordHash = "hashedPassword" };
        var password = "Test123!";
        var token = "validToken";

        A.CallTo(() => _userRepository.GetByEmailAsync(user.Email)).Returns(Task.FromResult(user));
        A.CallTo(() => _passwordHasher.VerifyPassword(password, user.PasswordHash)).Returns(true);
        A.CallTo(() => _jwtService.GenerateToken(user)).Returns(token);

        var result = await _authService.Login(user.Email, password);

        Assert.NotNull(result);
        Assert.Equal(token, result);
    }
}
