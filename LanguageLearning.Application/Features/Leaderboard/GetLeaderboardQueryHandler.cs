using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Features.Leaderboard.Queries
{
    public class GetLeaderboardQueryHandler : IRequestHandler<GetLeaderboardQuery, List<LeaderboardEntry>>
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public GetLeaderboardQueryHandler(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public async Task<List<LeaderboardEntry>> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
        {
            return await _leaderboardRepository.GetAllAsync();
        }
    }
}
