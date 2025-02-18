
using MediatR;
namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateChallengeCommand : IRequest<bool>
    {
        public int ChallengeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
