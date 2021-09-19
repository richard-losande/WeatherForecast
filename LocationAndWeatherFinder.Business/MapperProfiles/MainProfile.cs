using AutoMapper;
using LocationAndWeatherFinder.Business.DataTransferObjects.Generics;
using LocationAndWeatherFinder.Service.Entities;

namespace LocationAndWeatherFinder.Business.MapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            Weather();
        }
        private void Weather()
        {
            CreateMap<WeatherOutputDto, WeatherOutput>().ReverseMap();
        }
    }
}
