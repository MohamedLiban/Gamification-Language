using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Features.Commands.UpdateCommands; 

namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateLeaderboardEntryCommandHandler : IRequestHandler<UpdateLeaderboardEntryCommand, bool>
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public UpdateLeaderboardEntryCommandHandler(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public async Task<bool> Handle(UpdateLeaderboardEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = await _leaderboardRepository.GetByIdAsync(request.Id);
            if (entry == null) return false;

            entry.UserId = request.UserId;
            entry.Score = request.Score;

            await _leaderboardRepository.UpdateAsync(entry);
            return true;
        }
    }
}
