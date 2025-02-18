using System.Threading.Tasks;

namespace LanguageLearning.Application.Interfaces
{
    public interface IChallengeGenerationService
    {
        Task<string> GenerateChallengeAsync(string prompt);
    }
}
