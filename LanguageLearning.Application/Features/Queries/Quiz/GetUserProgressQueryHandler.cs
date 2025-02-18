using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    public class GetUserProgressQueryHandler : IRequestHandler<GetUserProgressQuery, List<UserProgress>>
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public GetUserProgressQueryHandler(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        public async Task<List<UserProgress>> Handle(GetUserProgressQuery request, CancellationToken cancellationToken)
        {
            return await _userProgressRepository.GetByUserIdAsync(request.UserId);
        }
    }
}