using Models.Completions;
using Newtonsoft.Json;
using Services.Interfaces;
using System.Net.Http.Json;

namespace Services.Services
{
    public class CompletionService : ICompletionService
    {
        private readonly HttpClient _httpClient;

        public CompletionService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<CompletionResponse> GetCompletion(CompletionRequest request)
        {
            var url = _httpClient.BaseAddress + "chat/completions";

            var json = JsonConvert.SerializeObject(request);
                        
            var response = await _httpClient.PostAsJsonAsync(url, request);
                         
            if(response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CompletionResponse>(responseContent);
                return result;
            }
            else
            {
                throw new Exception($"OpenAI API returned status code {response.StatusCode}.");
            }
        }
    }

}
