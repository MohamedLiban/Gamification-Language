using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Domain.Entities
{
    public class UserProgress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Progress { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }

        public User User { get; set; }
        public Quiz Quiz { get; set; }
    }
}
