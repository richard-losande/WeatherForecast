using LocationAndWeatherFinder.Business.LogicCollections;
using LocationAndWeatherFinder.Service.Entities;
using System.Threading.Tasks;

namespace LocationAndWeatherFinder.Service.ServiceCollection
{
    public interface IWeatherService
    {
        ApiResult<WeatherOutput.WeatherDetailedOutput> Get(string cityName);
    }
}
