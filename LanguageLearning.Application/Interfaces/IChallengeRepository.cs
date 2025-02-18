
using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;
namespace LanguageLearning.Application.Interfaces
{
    public interface IChallengeRepository
    {
        Task<List<Challenge>> GetAllAsync();
        Task<Challenge> GetByIdAsync(int id);
        Task AddAsync(Challenge challenge);
        Task UpdateAsync(Challenge challenge);
        Task DeleteAsync(int id);
    }
}
