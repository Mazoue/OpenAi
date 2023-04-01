using Models.Completions;

namespace Services.Interfaces
{
    public interface ICompletionService
    {
        Task<CompletionResponse> GetCompletion(CompletionRequest request);
    }
}
