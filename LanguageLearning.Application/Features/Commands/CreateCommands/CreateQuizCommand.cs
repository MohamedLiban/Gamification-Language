using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateQuizCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
