using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateLeaderboardEntryCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
