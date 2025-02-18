using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;

namespace LanguageLearning.Application.Features.Queries.Quiz
{
    public class GetUserProgressQuery : IRequest<List<UserProgress>>
    {
        public int UserId { get; set; }

        public GetUserProgressQuery(int userId)
        {
            UserId = userId;
        }
    }
}