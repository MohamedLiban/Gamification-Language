
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateChallengeCommandHandler : IRequestHandler<UpdateChallengeCommand, bool>
    {
        private readonly IChallengeRepository _challengeRepository;
        public UpdateChallengeCommandHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        public async Task<bool> Handle(UpdateChallengeCommand request, CancellationToken cancellationToken)
        {
            var challenge = await _challengeRepository.GetByIdAsync(request.ChallengeId);
            if (challenge == null)
                return false;

            challenge.Name = request.Title;  
            challenge.Description = request.Description;
            challenge.Difficulty = request.DifficultyLevel;  

            await _challengeRepository.UpdateAsync(challenge);
            return true;
        }

    }
}
