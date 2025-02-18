using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();
        Task<Quiz> GetByIdAsync(int id);
        Task AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(int id);
    }
}
