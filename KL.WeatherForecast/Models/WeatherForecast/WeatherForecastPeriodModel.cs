namespace KL.WeatherForecast.Api.Models.WeatherForecast
{
    public class WeatherForecastPeriodModel
    {
        public string DetailedForecast { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDaytime { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime StartTime { get; set; }
        public string ShortForecast { get; set; }
        public int Temperature { get; set; }
        public string TemperatureUnit { get; set; }
    }
}