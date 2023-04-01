using Models.Config;
using Services.Interfaces;
using Services.Services;
using System.Net.Http.Headers;

namespace OpenAi.Startup
{
    public static class AddOpenAiServicesExtension
    {
        public static IServiceCollection AddOpenAiServices(this IServiceCollection services, OpenAiSettings openAiSettings)
        {
            services.AddHttpClient<ICompletionService, CompletionService>(client =>
            {
                client.BaseAddress = new Uri(openAiSettings.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiSettings.ApiKey);
            });

            return services;
        }
    }
}
