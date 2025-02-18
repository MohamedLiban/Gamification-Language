using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Features.Queries.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.UserId); 
        }
    }
}
