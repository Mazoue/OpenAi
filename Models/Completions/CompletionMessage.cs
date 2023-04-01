using Newtonsoft.Json;

namespace Models.Completions
{
    public class CompletionMessage
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
