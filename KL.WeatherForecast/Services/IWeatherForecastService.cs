using Microsoft.AspNetCore.Mvc;

namespace KL.WeatherForecast.Api.Services
{
    public interface IWeatherForecastService
    {
        Task<ActionResult> GetWeatherForecast(string fullAddress);
    }
}
