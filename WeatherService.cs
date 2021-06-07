using System;
using System.Threading.Tasks;

namespace BlazorWasmPostRenderInitialization
{
    public class WeatherService : IDisposable
    {
        private readonly FirstRenderStateContainer _firstRenderStateContainer;

        public WeatherService(FirstRenderStateContainer firstRenderStateContainer)
        {
            Console.WriteLine("WeatherService: Constructor");
            _firstRenderStateContainer = firstRenderStateContainer;
            firstRenderStateContainer.OnFirstRender += InitializeWeatherAsync;
        }

        private async void InitializeWeatherAsync()
        {
            Console.WriteLine("WeatherService: Initialization started");
            await Task.Delay(10000);
            Console.WriteLine("WeatherService: Initialization completed");
        }

        public void Dispose() => _firstRenderStateContainer.OnFirstRender -= InitializeWeatherAsync;
    }
}
