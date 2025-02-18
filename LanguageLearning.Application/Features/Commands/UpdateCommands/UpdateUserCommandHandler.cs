using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId); 

            if (user == null) return false;

            user.Username = request.Username;
            user.Email = request.Email;

            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
