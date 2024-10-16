using Blazored.LocalStorage;
using Dictionary.CLient.Blazor.WebApi.Extnsions;
using Dictionary.CLient.Blazor.WebApi.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Dictionary.CLient.Blazor.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7155/api") });
            builder.Services.AddService();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthProvider>();

            builder.Services.AddAuthorizationCore();
            await builder.Build().RunAsync();
        }
    }
}
