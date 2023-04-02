using Newtonsoft.Json;

namespace Models.Completions
{
    public class CompletionRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("temperature")]
        public decimal Temperature { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonProperty("messages")]
        public List<CompletionMessage> Messages { get; set; }
    }
}
