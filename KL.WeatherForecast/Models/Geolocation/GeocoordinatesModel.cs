using Newtonsoft.Json;

namespace KL.WeatherForecast.Api.Models.Geolocation
{
    public class GeocoordinatesModel
    {
        [JsonProperty("X")]
        public string Longitude { get; set; }

        [JsonProperty("Y")]
        public string Latitude { get; set; }
    }
}