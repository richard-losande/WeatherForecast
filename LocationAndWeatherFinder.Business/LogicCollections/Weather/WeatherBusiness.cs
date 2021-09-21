using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocationAndWeatherFinder.Business.DataTransferObjects;
using LocationAndWeatherFinder.Business.DataTransferObjects.Generics;
using LocationAndWeatherFinder.Service.ServiceCollection;

namespace LocationAndWeatherFinder.Business.LogicCollections.Weather
{
    public class WeatherBusiness : IWeatherBusiness
    {
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;
        public WeatherBusiness(IWeatherService weatherService, IMapper mapper)
        {
            _weatherService = weatherService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get weather details using cityname
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns weather details</returns>
        public ResultGeneric<List<WeatherOutputDto>> ProcessWeather(LocationInputDto input)
        {
            var listOfCity = new List<CityDto>();
            var result = new List<WeatherOutputDto>();
            if (!input.File.FileName.EndsWith(".csv"))
                throw new Exception("Input should be in csv format.");

            ExtractDataFromFile(input, listOfCity);
            ProcessResponse(listOfCity, result);
            return GetResultGeneric(result);
        }

        private void ProcessResponse(List<CityDto> listOfCity, List<WeatherOutputDto> result)
        {
            result.AddRange(listOfCity.Select(city => _weatherService.ProcessWeather(city.CityName))
            .Select(response => new WeatherOutputDto()
            {
                City = response.Data.name,
                Country = response.Data.sys.country,
                Lat = response.Data.coord.lat,
                Lon = response.Data.coord.lon,
                Description = response.Data.weather[0].description,
                Humidity = response.Data.main.humidity,
                Temp = response.Data.main.temp,
                TempMax = response.Data.main.temp_max,
                TempMin = response.Data.main.temp_min,
                TempFeelsLike = response.Data.main.feels_like,
                WeatherIcon = response.Data.weather[0].icon
            }));
        }

        private static void ExtractDataFromFile(LocationInputDto input, List<CityDto> listOfCity)
        {
            using var streamReader = new StreamReader(input.File.OpenReadStream());
            streamReader.ReadLine(); //skip first row
            while (!streamReader.EndOfStream)
            {
                var rows = streamReader.ReadLine();
                var city = new CityDto()
                {
                    CityName = rows
                };
                listOfCity.Add(city);
            }
        }

        protected ResultGeneric<TOutput> GetResultGeneric<TOutput>(TOutput request)
        {
            var result = new ResultGeneric<TOutput>
            {
                Data = request
            };
            return result;
        }
    }   
}
