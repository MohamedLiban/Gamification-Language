using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteUserProgressCommand : IRequest<bool>
    {
        public int UserProgressId { get; set; } 
    }
}
