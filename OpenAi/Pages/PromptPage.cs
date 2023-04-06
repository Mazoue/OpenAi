using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

        protected List<(string Prompt, string Response, DateTime Timestamp)> PromptResponses = new();


        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected async Task OnEnterKeyPressed(KeyboardEventArgs e)
        {
            if(e.Key == "Enter")
            {
                await ShowPrompt();
            }
        }

        protected async Task ShowPrompt()
        {
            // Call the GetCompletion method of the ICompletionService interface
            var completionRequest = new CompletionRequest {
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
            PromptResult = completionResponse.Choices[0].Message.Content;
            PromptResponses.Add((PromptText, PromptResult, DateTime.Now));
            PromptText = "";
            StateHasChanged();
        }

        protected void ClearChatHistory()
        {
            PromptResponses.Clear();
        }

    }
}
