using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateChallengeCommand : IRequest<int>
    {
        public string Name { get; set; }  
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
