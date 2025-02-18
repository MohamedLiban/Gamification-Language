using LanguageLearning.Domain.Entities;
using MediatR;

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    using QuizEntity = LanguageLearning.Domain.Entities.Quiz; 

    public class GetQuizByIdQuery : IRequest<QuizEntity>
    {
        public int QuizId { get; set; }

        public GetQuizByIdQuery(int quizId)
        {
            QuizId = quizId;
        }
    }
}
