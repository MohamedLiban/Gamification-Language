using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateChallengeCommandHandler : IRequestHandler<CreateChallengeCommand, int>
    {
        private readonly IChallengeRepository _challengeRepository;

        public CreateChallengeCommandHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }

        public async Task<int> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
        {
            var challenge = new Challenge
            {
                Name = request.Name,
                Description = request.Description
            };

            await _challengeRepository.AddAsync(challenge);
            return challenge.Id;
        }
    }
}
