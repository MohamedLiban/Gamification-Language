using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Repositories
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaderboardEntry> GetByIdAsync(int id)
        {
            return await _context.LeaderboardEntries.FindAsync(id);
        }

        public async Task<List<LeaderboardEntry>> GetAllAsync()
        {
            return await _context.LeaderboardEntries.ToListAsync();
        }

        public async Task AddAsync(LeaderboardEntry entry)
        {
            await _context.LeaderboardEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LeaderboardEntry entry)
        {
            _context.LeaderboardEntries.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _context.LeaderboardEntries.FindAsync(id);
            if (entry != null)
            {
                _context.LeaderboardEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
