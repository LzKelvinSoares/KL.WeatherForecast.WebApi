using KL.WeatherForecast.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KL.WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            this._weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return new OkObjectResult("WEATHER API ON");
        }

        [HttpGet("{address}")]
        public async Task<ActionResult> Get(string address)
        {
            return await this._weatherForecastService.GetWeatherForecast(address);
        }
    }
}