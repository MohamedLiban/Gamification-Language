using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLearning.Application.Features.Users.Commands
{
    public class UpdateUserProgressCommandHandler : IRequestHandler<UpdateUserProgressCommand, bool>
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public UpdateUserProgressCommandHandler(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        public async Task<bool> Handle(UpdateUserProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = await _userProgressRepository.GetByIdAsync(request.Id);
            if (progress == null) return false;

            progress.UserId = request.UserId;
            progress.QuizId = request.QuizId;
            progress.IsCompleted = request.IsCompleted;

            await _userProgressRepository.UpdateAsync(progress);
            return true;
        }
    }
}
