namespace KL.WeatherForecast.Api.Models.WeatherForecast
{
    public class WeatherForecastPointsPropertiesModel
    {
        public IList<WeatherForecastPeriodModel> Periods { get; set; }
        public string Forecast { get; set; }
    }
}
