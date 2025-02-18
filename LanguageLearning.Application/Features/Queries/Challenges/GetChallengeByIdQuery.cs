
using MediatR;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Queries.Challenges
{
    public class GetChallengeByIdQuery : IRequest<Challenge>
    {
        public int ChallengeId { get; set; }
        public GetChallengeByIdQuery(int challengeId)
        {
            ChallengeId = challengeId;
        }
    }
}
