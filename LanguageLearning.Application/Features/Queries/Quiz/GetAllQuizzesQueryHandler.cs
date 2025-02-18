using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities; 

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    public class GetAllQuizzesQueryHandler : IRequestHandler<GetAllQuizzesQuery, List<LanguageLearning.Domain.Entities.Quiz>> 
    {
        private readonly IQuizRepository _quizRepository;

        public GetAllQuizzesQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<LanguageLearning.Domain.Entities.Quiz>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken) 
        {
            return await _quizRepository.GetAllAsync();
        }
    }
}
