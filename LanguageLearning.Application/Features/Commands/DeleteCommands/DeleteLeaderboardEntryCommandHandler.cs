using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Features.Commands.DeleteCommands;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteLeaderboardEntryCommandHandler : IRequestHandler<DeleteLeaderboardEntryCommand, bool>
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public DeleteLeaderboardEntryCommandHandler(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public async Task<bool> Handle(DeleteLeaderboardEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = await _leaderboardRepository.GetByIdAsync(request.LeaderboardEntryId);
            if (entry == null) return false;

            await _leaderboardRepository.DeleteAsync(entry.Id);
            return true;
        }
    }
}
