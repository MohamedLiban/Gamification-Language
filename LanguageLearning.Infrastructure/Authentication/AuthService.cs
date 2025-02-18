using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using System.Threading.Tasks;

namespace LanguageLearning.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<string> Register(string email, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(password);
            var user = new User { Email = email, PasswordHash = hashedPassword };

            await _userRepository.AddAsync(user);
            return _jwtService.GenerateToken(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            return _jwtService.GenerateToken(user);
        }
    }
}

