using KL.WeatherForecast.Api.Models.WeatherForecast;
using KL.WeatherForecast.Api.Models.Geolocation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KL.WeatherForecast.Api.Services.Handlers
{
    public class WeatherForecastServiceHandler : IWeatherForecastService
    {
        private readonly IConfiguration _configuration;
        private readonly IGeolocationService _geolocationService;
        private readonly IHttpService _httpService;
        public WeatherForecastServiceHandler(IHttpService httpService, IGeolocationService geolocationService,
            IConfiguration configuration)
        {
            this._configuration = configuration;
            this._geolocationService = geolocationService;
            this._httpService = httpService;
        }

        public async Task<ActionResult> GetWeatherForecast(string fullAddress)
        {
            try
            {
                var coordinates = await GetCoordinates(fullAddress);
                var url = await GetForecastPropertiesUrl(coordinates);
                var weatherForecastResult = await this._httpService.GetAsync<WeatherForecastPointsResultModel>(url);
                if (weatherForecastResult != null)
                {
                    return new OkObjectResult(weatherForecastResult.Properties.Periods);
                }
                else
                {
                    throw new WebException("No forecast");
                }
            }
            catch (WebException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        private async Task<GeocoordinatesModel> GetCoordinates(string fullAddress)
        {
            var geolocation = await this._geolocationService.GetGeolocation(fullAddress);
            var addressMatches = geolocation.AddressMatches.FirstOrDefault();
            if (addressMatches != null)
            {
                return addressMatches.Coordinates;
            }
            else
            {
                throw new WebException("No matched address");
            }
        }

        private async Task<string> GetForecastPropertiesUrl(GeocoordinatesModel coordinates)
        {
            var weatherApi = this._configuration.GetSection("ApiUrls:Weather").Value;
            var url = String.Format("{0}/points/{1},{2}", weatherApi, coordinates.Latitude, coordinates.Longitude);
            var propertiesContainer = await this._httpService.GetAsync<WeatherForecastPointsResultModel>(url);
            if (propertiesContainer != null)
            {
                return propertiesContainer.Properties.Forecast;
            }
            else
            {
                throw new WebException("No forecast url");
            }
        }
    }
}
