
using System.Collections.Generic;
using MediatR;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Features.Queries.Challenges
{
    public class GetAllChallengesQuery : IRequest<List<Challenge>> { }
}
