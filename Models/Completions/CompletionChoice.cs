using Newtonsoft.Json;

namespace Models.Completions
{
    public class CompletionChoice
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("logprobs")]
        public dynamic LogProbs { get; set; }

        [JsonProperty("text_offset")]
        public int TextOffset { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
