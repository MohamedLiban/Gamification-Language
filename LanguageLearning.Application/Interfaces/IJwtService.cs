using LanguageLearning.Domain.Entities;

namespace LanguageLearning.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
