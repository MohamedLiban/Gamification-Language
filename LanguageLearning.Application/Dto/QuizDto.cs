using System.Collections.Generic;
using LanguageLearning.Domain.Enums;

namespace LanguageLearning.Application.DTOs
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
