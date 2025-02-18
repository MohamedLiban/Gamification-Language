
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Queries.Challenges
{
    public class GetChallengeByIdQueryHandler : IRequestHandler<GetChallengeByIdQuery, Challenge>
    {
        private readonly IChallengeRepository _challengeRepository;
        public GetChallengeByIdQueryHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        public async Task<Challenge> Handle(GetChallengeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _challengeRepository.GetByIdAsync(request.ChallengeId);
        }
    }
}
