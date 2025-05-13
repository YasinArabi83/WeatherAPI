using Newtonsoft.Json.Linq;

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

        public static WeatherModel ParseWeather(string json)
        {
            var root = JObject.Parse(json);

            var weather = new WeatherModel
            {
                Temp = root["main"]?["temp"]?.ToObject<double>() ?? 0,
                FeelsTemp = root["main"]?["feels_like"]?.ToObject<double>() ?? 0,
                Humidity = root["main"]?["humidity"]?.ToObject<int>() ?? 0,
                WindSpeed = root["wind"]?["speed"]?.ToObject<double>() ?? 0,
                LocationInfo = null,
                AirPollutionInfo = null
            };

            return weather;
        }
    }
}
