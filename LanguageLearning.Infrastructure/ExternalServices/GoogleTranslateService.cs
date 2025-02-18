
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using Google.Cloud.Translation.V2;
namespace LanguageLearning.Infrastructure.ExternalServices
{
    public class GoogleTranslationService : ITranslationService
    {
        private readonly TranslationClient _client;
        public GoogleTranslationService(string apiKey)
        {
            _client = TranslationClient.CreateFromApiKey(apiKey);
        }
        public async Task<string> TranslateAsync(string text, string targetLanguage)
        {
            var result = await Task.Run(() => _client.TranslateText(text, targetLanguage));
            return result.TranslatedText;
        }
    }
}
