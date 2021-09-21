using LocationAndWeatherFinder.Business.DataTransferObjects;
using LocationAndWeatherFinder.Business.LogicCollections.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocationAndWeatherFinder.Controllers
{
    /// <summary>
    /// All endpoints that are related to weather
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IWeatherBusiness _weatherBusiness;

        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, IWeatherBusiness weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }
        /// <summary>
        /// Endpoint to get weather details using city names
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("Details")]
        public OkObjectResult Post([FromForm] LocationInputDto input)
        {
            return Ok(_weatherBusiness.ProcessWeather(input));
        }
    }
}
