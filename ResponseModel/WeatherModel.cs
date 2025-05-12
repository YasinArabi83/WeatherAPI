namespace WeatherAPI.ResponseModel
{
    public class WeatherModel
    {
        public double Temp { get; set; }
        public double FeelsTemp { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public AirPollutionModel? AirPollutionInfo { get; set; }
        public CityModel? LocationInfo { get; set; }
    }
}
