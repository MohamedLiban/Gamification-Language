using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Repositories
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly ApplicationDbContext _context;

        public ChallengeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Challenge>> GetAllAsync()
        {
            return await _context.Challenges.ToListAsync();
        }

        public async Task<Challenge> GetByIdAsync(int id)
        {
            return await _context.Challenges.FindAsync(id);
        }

        public async Task AddAsync(Challenge challenge)
        {
            await _context.Challenges.AddAsync(challenge);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Challenge challenge)
        {
            _context.Challenges.Update(challenge);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var challenge = await _context.Challenges.FindAsync(id);
            if (challenge != null)
            {
                _context.Challenges.Remove(challenge);
                await _context.SaveChangesAsync();
            }
        }
    }
}

