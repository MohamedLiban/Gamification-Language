using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteChallengeCommand : IRequest<bool>
    {
        public int ChallengeId { get; set; }

        public DeleteChallengeCommand(int challengeId)
        {
            ChallengeId = challengeId;
        }
    }
}
