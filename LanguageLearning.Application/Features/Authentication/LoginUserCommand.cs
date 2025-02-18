using MediatR;

namespace LanguageLearning.Application.Features.Authentication
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
