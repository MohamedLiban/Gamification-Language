using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteChallengeCommandHandler : IRequestHandler<DeleteChallengeCommand, bool>
    {
        private readonly IChallengeRepository _challengeRepository;

        public DeleteChallengeCommandHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }

        public async Task<bool> Handle(DeleteChallengeCommand request, CancellationToken cancellationToken)
        {
            var challenge = await _challengeRepository.GetByIdAsync(request.ChallengeId);
            if (challenge == null) return false;

            await _challengeRepository.DeleteAsync(request.ChallengeId);
            return true;
        }
    }
}
