using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using Newtonsoft.Json;

namespace LanguageLearning.Infrastructure.ExternalServices
{
    public class OpenAIService : IChallengeGenerationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _httpClient.BaseAddress = new System.Uri("https://api.openai.com/v1/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GenerateChallengeAsync(string prompt)
        {
            var requestData = new
            {
                model = "text-davinci-003",
                prompt = prompt,
                max_tokens = 150
            };

            var jsonRequest = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("completions", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.choices[0].text;
        }
    }
}
