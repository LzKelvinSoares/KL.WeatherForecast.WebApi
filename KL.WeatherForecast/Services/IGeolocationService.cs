using KL.WeatherForecast.Api.Models.Geolocation;

namespace KL.WeatherForecast.Api.Services
{
    public interface IGeolocationService
    {
        Task<GeolocationModel> GetGeolocation(string fullAddress);
    }
}
