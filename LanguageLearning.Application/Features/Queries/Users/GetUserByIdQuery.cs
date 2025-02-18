using LanguageLearning.Domain.Entities;
using MediatR;

namespace LanguageLearning.Application.Features.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; } 

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
