using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Features.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
