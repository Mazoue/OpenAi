using Models.CompletionResponse;
using Models.Completions;

namespace Services.Interfaces
{
    public interface ICompletionService
    {
        Task<ChatCompletion> GetCompletion(CompletionRequest request);
    }
}
