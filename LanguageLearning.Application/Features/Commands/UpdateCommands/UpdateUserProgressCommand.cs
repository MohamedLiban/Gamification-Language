using MediatR;

namespace LanguageLearning.Application.Features.Users.Commands
{
    public class UpdateUserProgressCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
