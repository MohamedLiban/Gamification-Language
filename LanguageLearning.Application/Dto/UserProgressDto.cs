namespace LanguageLearning.Application.DTOs
{
    public class UserProgressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public int Attempts { get; set; }
    }
}
