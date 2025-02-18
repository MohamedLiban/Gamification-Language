using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
