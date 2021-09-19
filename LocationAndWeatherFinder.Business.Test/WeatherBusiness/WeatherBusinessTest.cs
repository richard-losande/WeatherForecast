using System.IO;
using System.Net;
using System.Text;
using AutoFixture;
using LocationAndWeatherFinder.Business.DataTransferObjects;
using LocationAndWeatherFinder.Business.DataTransferObjects.Generics;
using LocationAndWeatherFinder.Business.LogicCollections;
using LocationAndWeatherFinder.Service.Entities;
using LocationAndWeatherFinder.Service.ServiceCollection;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace LocationAndWeatherFinder.Business.Tests.WeatherBusiness
{
    public class WeatherBusinessTest : BaseBusinessTest
    {
        [Test]
        public void WeatherForeCastGet_ShouldReturn_DataResult()
        {
            //arrange
            var cityName = "Manila";
            var input = new LocationInputDto()
            {
                File = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file"))
                    , 0, 0, "Data", "dummy.csv")
            };
            var weatherServiceMock = Repository.Create<ApiResult<WeatherService>>();
            var weatherOutputDtoMock = Repository.Create<WeatherOutputDto>();
            
            var weatherDetailedOutputMock = Repository.Create<WeatherOutput.WeatherDetailedOutput>();
            weatherOutputDtoMock.SetupAllProperties();
            weatherOutputDtoMock.Object.City = "Manila";
            weatherOutputDtoMock.Object.City = "PH";

            weatherServiceMock.Object.StatusCode = HttpStatusCode.OK;
            var weatherServiceResultMock = Repository.Create<ApiResult<WeatherOutput.WeatherDetailedOutput>>();
            weatherServiceResultMock.Object.Data = weatherDetailedOutputMock.Object;
            weatherServiceResultMock.Object.StatusCode = HttpStatusCode.OK;

            Fixture.Inject(weatherServiceMock);
            //act
            var target = Fixture.Create<LogicCollections.Weather.WeatherBusiness>();
            var result = target.GetWeather(input);
            //assert
            Assert.IsNotNull(result.Data);
            Repository.VerifyAll();

        }
    }
}
