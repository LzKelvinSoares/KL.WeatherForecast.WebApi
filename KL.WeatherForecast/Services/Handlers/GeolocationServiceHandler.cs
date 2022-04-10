using KL.WeatherForecast.Api.Models.Geolocation;
using System.Net;

namespace KL.WeatherForecast.Api.Services.Handlers
{
    public class GeolocationServiceHandler : IGeolocationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;
        public GeolocationServiceHandler(IHttpService httpService, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._httpService = httpService;
        }

        public async Task<GeolocationModel> GetGeolocation(string fullAddress)
        {
            var geolocationApi = this._configuration.GetSection("ApiUrls:Geolocation").Value;
            var url = String.Format("{0}?address={1}&benchmark=2020&format=json", geolocationApi, fullAddress);
            var geolocationResult = await this._httpService.GetAsync<GeolocationResultModel>(url);
            if (geolocationResult != null)
            {
                return geolocationResult.Result;
            }
            else
            {
                throw new WebException("No matched address");
            }
        }
    }
}
