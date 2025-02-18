using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Infrastructure.Repositories
{
    public class UserProgressRepository : IUserProgressRepository
    {
        private readonly List<UserProgress> _userProgresses = new List<UserProgress>();

        public Task<List<UserProgress>> GetAllAsync()
        {
            return Task.FromResult(_userProgresses);
        }

        public Task<UserProgress> GetByIdAsync(int id)
        {
            var progress = _userProgresses.FirstOrDefault(up => up.Id == id);
            return Task.FromResult(progress);
        }

        public Task<List<UserProgress>> GetByUserIdAsync(int userId)
        {
            var progresses = _userProgresses.Where(up => up.UserId == userId).ToList();
            return Task.FromResult(progresses);
        }

        public Task AddAsync(UserProgress userProgress)
        {
            userProgress.Id = _userProgresses.Count + 1;
            _userProgresses.Add(userProgress);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(UserProgress userProgress)
        {
            var existing = _userProgresses.FirstOrDefault(up => up.Id == userProgress.Id);
            if (existing != null)
            {
                existing.UserId = userProgress.UserId;
                existing.QuizId = userProgress.QuizId;
                existing.Score = userProgress.Score;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var progress = _userProgresses.FirstOrDefault(up => up.Id == id);
            if (progress != null)
            {
                _userProgresses.Remove(progress);
            }
            return Task.CompletedTask;
        }
    }
}
