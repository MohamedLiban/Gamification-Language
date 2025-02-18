using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using MediatR;

namespace LanguageLearning.Application.Features.Authentication
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
                return null;

            return _jwtService.GenerateToken(user);
        }
    }
}
