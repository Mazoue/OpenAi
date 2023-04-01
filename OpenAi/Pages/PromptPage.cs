using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.JSInterop;
using Models.Completions;
using Services.Interfaces;

namespace OpenAi.Pages
{
    public class PromptPageModel : ComponentBase
    {
        [Inject]
        protected ICompletionService CompletionService { get; set; }

        protected string PromptText { get; set; }
        protected string PromptResult { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        //protected async Task ShowPrompt()
        //{
        //    PromptResult = await JSRuntime.InvokeAsync<string>("prompt", PromptText);
        //    StateHasChanged();
        //}

        protected async Task ShowPrompt()
        {
            // Call the GetCompletion method of the ICompletionService interface
            var completionRequest = new CompletionRequest {
                Prompt = PromptText,
                Model = "gpt-3.5-turbo",
                MaxTokens = 100,
                Temperature = 1,
                Messages = new List<CompletionMessage>
                {
                    new CompletionMessage
                    {
                        Role = "user",
                        Content = PromptText
                    }
                }
            };
            var completionResponse = await CompletionService.GetCompletion(completionRequest);
            PromptResult = completionResponse.Choices[0].Text;
            StateHasChanged();
        }

    }
}
