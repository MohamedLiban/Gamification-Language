using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Features.Commands.CreateCommands; 

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(request.Password)
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
