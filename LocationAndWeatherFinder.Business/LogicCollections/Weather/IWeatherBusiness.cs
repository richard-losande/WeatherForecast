using LocationAndWeatherFinder.Business.DataTransferObjects;
using LocationAndWeatherFinder.Business.DataTransferObjects.Generics;
using System.Collections.Generic;

namespace LocationAndWeatherFinder.Business.LogicCollections.Weather
{
    public interface IWeatherBusiness
    {
        ResultGeneric<List<WeatherOutputDto>> ProcessWeather(LocationInputDto input);
    }
}
