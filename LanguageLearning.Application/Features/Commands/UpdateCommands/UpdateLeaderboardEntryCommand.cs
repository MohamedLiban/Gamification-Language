using MediatR;

namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateLeaderboardEntryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
