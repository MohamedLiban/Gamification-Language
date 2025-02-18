using System.Collections.Generic;
using LanguageLearning.Domain.Entities;
using MediatR;

namespace LanguageLearning.Application.Features.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<User>> { }
}
