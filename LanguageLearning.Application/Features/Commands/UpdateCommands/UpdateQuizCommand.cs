using MediatR;

namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateQuizCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public int QuizId { get; set; }
    }
}
