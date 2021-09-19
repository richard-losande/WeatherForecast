using LocationAndWeatherFinder.Business.LogicCollections;
using LocationAndWeatherFinder.Service.Entities;
using Microsoft.Extensions.Configuration;

namespace LocationAndWeatherFinder.Service.ServiceCollection
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IConfiguration _configuration;
        public WeatherService(IHttpClientWrapper httpClientWrapper, IConfiguration configuration)
        {
            _httpClientWrapper = httpClientWrapper;
            _configuration = configuration;
        }

        public ApiResult<WeatherOutput.WeatherDetailedOutput> Get(string cityName)
        {
            var openWeatherKey = _configuration["OpenWeatherMapApi:Key"];
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&cnt=1&APPID={openWeatherKey}";
            return _httpClientWrapper.Get<string, WeatherOutput.WeatherDetailedOutput>(url);
        }
    }
}
