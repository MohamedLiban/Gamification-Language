using MediatR;
using System.Collections.Generic;
using LanguageLearning.Domain.Entities; 

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    public class GetAllQuizzesQuery : IRequest<List<LanguageLearning.Domain.Entities.Quiz>>
    {
    }
}
