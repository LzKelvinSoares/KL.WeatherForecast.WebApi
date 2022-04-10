namespace KL.WeatherForecast.Api.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
    }
}
