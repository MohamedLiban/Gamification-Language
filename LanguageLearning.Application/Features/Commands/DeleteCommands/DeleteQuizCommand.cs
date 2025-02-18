using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteQuizCommand : IRequest<bool>
    {
        public int QuizId { get; set; }
        public int Id { get; set; }  
    }
}
