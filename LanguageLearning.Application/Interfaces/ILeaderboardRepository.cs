using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Interfaces
{
    public interface ILeaderboardRepository
    {
        Task<LeaderboardEntry> GetByIdAsync(int id);
        Task<List<LeaderboardEntry>> GetAllAsync();
        Task AddAsync(LeaderboardEntry entry);
        Task UpdateAsync(LeaderboardEntry entry);
        Task DeleteAsync(int id);
    }
}
