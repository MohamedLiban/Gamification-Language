using LanguageLearning.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteUserProgressCommandHandler : IRequestHandler<DeleteUserProgressCommand, bool>
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public DeleteUserProgressCommandHandler(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        public async Task<bool> Handle(DeleteUserProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = await _userProgressRepository.GetByIdAsync(request.UserProgressId);
            if (progress == null) return false;

            await _userProgressRepository.DeleteAsync(progress.Id); 
            return true;

        }
    }
}
