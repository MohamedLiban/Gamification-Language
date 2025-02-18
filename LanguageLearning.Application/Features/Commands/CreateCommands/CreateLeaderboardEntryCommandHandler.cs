using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Features.Commands.CreateCommands;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateLeaderboardEntryCommandHandler : IRequestHandler<CreateLeaderboardEntryCommand, int>
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public CreateLeaderboardEntryCommandHandler(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public async Task<int> Handle(CreateLeaderboardEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = new LeaderboardEntry
            {
                UserId = request.UserId,
                Score = request.Score
            };

            await _leaderboardRepository.AddAsync(entry);
            return entry.Id;
        }
    }
}
