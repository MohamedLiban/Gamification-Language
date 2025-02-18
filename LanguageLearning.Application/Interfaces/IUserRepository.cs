using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email); 
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
