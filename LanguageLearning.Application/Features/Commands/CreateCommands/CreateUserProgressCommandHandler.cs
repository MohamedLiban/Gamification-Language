using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateUserProgressCommandHandler : IRequestHandler<CreateUserProgressCommand, int>
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public CreateUserProgressCommandHandler(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        public async Task<int> Handle(CreateUserProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = new UserProgress
            {
                UserId = request.UserId,
                QuizId = request.QuizId,
                Progress = request.Progress,
                IsCompleted = request.IsCompleted
            };

            await _userProgressRepository.AddAsync(progress);
            return progress.Id;
        }
    }
}
