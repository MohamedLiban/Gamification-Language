using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    using QuizEntity = LanguageLearning.Domain.Entities.Quiz; 

    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, QuizEntity>
    {
        private readonly IQuizRepository _quizRepository;

        public GetQuizByIdQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<QuizEntity> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            return await _quizRepository.GetByIdAsync(request.QuizId);
        }
    }
}
