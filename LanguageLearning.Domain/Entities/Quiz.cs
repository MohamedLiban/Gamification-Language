using LanguageLearning.Domain.Enums;
using System.Collections.Generic;

namespace LanguageLearning.Domain.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DifficultyLevel DifficultyLevel { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
