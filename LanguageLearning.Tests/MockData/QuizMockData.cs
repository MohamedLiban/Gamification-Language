using System.Collections.Generic;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Domain.Enums;

namespace LanguageLearning.Tests.MockData
{
    public static class QuizMockData
    {
        public static List<Quiz> GetQuizzes()
        {
            return new List<Quiz>
            {
                new Quiz { Id = 1, Title = "Math Basics", DifficultyLevel = (DifficultyLevel)1 }, 
                new Quiz { Id = 2, Title = "Science Trivia", DifficultyLevel = (DifficultyLevel)2 } 
            };
        }
    }
}
