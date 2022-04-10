namespace KL.WeatherForecast.Api.Models.Geolocation
{
    public class AddressModel
    {
        public string MatchedAddress { get; set; }
        public GeocoordinatesModel Coordinates { get; set; }
    }
}