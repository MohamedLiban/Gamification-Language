using MediatR;

namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteLeaderboardEntryCommand : IRequest<bool>
    {
        public int LeaderboardEntryId { get; set; } 
    }
}
