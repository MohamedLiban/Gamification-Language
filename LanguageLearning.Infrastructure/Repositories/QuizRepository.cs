using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private static List<Quiz> _quizzes = new List<Quiz>();

        public Task<List<Quiz>> GetAllAsync()
        {
            return Task.FromResult(_quizzes);
        }

        public Task<Quiz> GetByIdAsync(int id)
        {
            var quiz = _quizzes.FirstOrDefault(q => q.Id == id);
            return Task.FromResult(quiz);
        }

        public Task AddAsync(Quiz quiz)
        {
            quiz.Id = _quizzes.Count + 1; 
            _quizzes.Add(quiz);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Quiz quiz)
        {
            var existingQuiz = _quizzes.FirstOrDefault(q => q.Id == quiz.Id);
            if (existingQuiz != null)
            {
                existingQuiz.Title = quiz.Title;
                existingQuiz.Description = quiz.Description;
                existingQuiz.DifficultyLevel = quiz.DifficultyLevel;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _quizzes.RemoveAll(q => q.Id == id);
            return Task.CompletedTask;
        }
    }
}
