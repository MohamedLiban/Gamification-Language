using MediatR;
using LanguageLearning.Domain.Entities;
using System.Collections.Generic;

namespace LanguageLearning.Application.Features.Leaderboard
{
    public class GetLeaderboardQuery : IRequest<List<LeaderboardEntry>> { }
}
