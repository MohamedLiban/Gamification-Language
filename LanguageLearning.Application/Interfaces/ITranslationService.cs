
using System.Threading.Tasks;
namespace LanguageLearning.Application.Interfaces
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string text, string targetLanguage);
    }
}
