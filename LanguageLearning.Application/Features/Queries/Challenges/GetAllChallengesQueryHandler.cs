
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Queries.Challenges
{
    public class GetAllChallengesQueryHandler : IRequestHandler<GetAllChallengesQuery, List<Challenge>>
    {
        private readonly IChallengeRepository _challengeRepository;
        public GetAllChallengesQueryHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        public async Task<List<Challenge>> Handle(GetAllChallengesQuery request, CancellationToken cancellationToken)
        {
            return await _challengeRepository.GetAllAsync();
        }
    }
}
