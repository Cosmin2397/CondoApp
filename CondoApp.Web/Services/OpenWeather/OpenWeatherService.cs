

using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.OpenWeather
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly HttpClient client;
        private readonly string apiKey;

        public OpenWeatherService(IConfiguration configuration)
        {
            client = new();
            apiKey = "d683460312d6b18506b40bd6ad6c3b5f";
        }

        
        private async Task<CurrentWeatherDTO> GetCurrentWeather()
        {
            CurrentWeatherDTO weatherForecast = new();
            string requestUri = GetCurrentWeatherRequestUri();

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
                weatherForecast = await response.Content.ReadAsAsync<CurrentWeatherDTO>();

            return weatherForecast;
        }

        private string GetCurrentWeatherRequestUri() =>
                    $"https://api.openweathermap.org/data/2.5/weather?lat=46.7667&lon=23.6&units=metric&appid={apiKey}";

        public async Task<WeatherDTO> GetWeather()
        {
            return new WeatherDTO
            {
                CurrentWeather = await GetCurrentWeather(),
            };
        }
    }
}

