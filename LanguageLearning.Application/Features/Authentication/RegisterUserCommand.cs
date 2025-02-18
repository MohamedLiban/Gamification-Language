using MediatR;

namespace LanguageLearning.Application.Features.Authentication
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
