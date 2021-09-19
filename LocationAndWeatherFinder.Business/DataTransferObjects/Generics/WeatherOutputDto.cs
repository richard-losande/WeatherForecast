namespace LocationAndWeatherFinder.Business.DataTransferObjects.Generics
{
    public class WeatherOutputDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Description { get; set; }
        public int Humidity { get; set; }
        public double TempFeelsLike { get; set; }
        public double Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string WeatherIcon { get; set; }
    }
}
