using Newtonsoft.Json;

namespace Models.Completions
{
    public class CompletionResponse
    {
        [JsonProperty("choices")]
        public List<CompletionChoice> Choices { get; set; }
    }
}
