using Models.CompletionResponse;
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

        public async Task<ChatCompletion> GetCompletion(CompletionRequest request)
        {
            var url = _httpClient.BaseAddress + "chat/completions";
                        
            var jsonRequest = JsonConvert.SerializeObject(request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(httpRequest);

            if(response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ChatCompletion>(responseContent);
                return result;
            }
            else
            {
                throw new Exception($"OpenAI API returned status code {response.StatusCode}.");
            }
        }
    }
}
