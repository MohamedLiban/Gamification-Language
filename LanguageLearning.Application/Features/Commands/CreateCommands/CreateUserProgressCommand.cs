using MediatR;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateUserProgressCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Progress { get; set; }
        public bool IsCompleted { get; set; }
        public int ChallengeId { get; set; }
    }
}
