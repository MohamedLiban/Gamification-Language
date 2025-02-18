using LanguageLearning.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId); 


            if (user == null) return false;

            await _userRepository.DeleteAsync(user.Id); 
            return true;

        }
    }
}
