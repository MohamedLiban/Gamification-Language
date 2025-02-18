using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; } 
    }
}
