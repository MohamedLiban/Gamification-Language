using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Interfaces
{
    public interface IUserProgressRepository
    {
        Task<List<UserProgress>> GetAllAsync();
        Task<UserProgress> GetByIdAsync(int id);
        Task<List<UserProgress>> GetByUserIdAsync(int userId);
        Task AddAsync(UserProgress userProgress);
        Task UpdateAsync(UserProgress userProgress);
        Task DeleteAsync(int id);
    }
}
