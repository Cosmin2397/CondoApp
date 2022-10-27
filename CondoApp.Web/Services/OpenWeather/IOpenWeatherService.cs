

using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.OpenWeather
{
    public interface IOpenWeatherService
    {
        Task<WeatherDTO> GetWeather();
    }
}
