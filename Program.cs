using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmPostRenderInitialization
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddSingleton<FirstRenderStateContainer>()
                .AddSingleton<WeatherService>();

            var host = builder.Build();
            // Creates WeatherService and runs WeatherService.ctor.
            // This ensures that WeatherService adds the callback method to FirstRenderStateContainer's delegate
            // before the application completes its first render.
            host.Services.GetRequiredService<WeatherService>();

            await host.RunAsync();
        }
    }
}
