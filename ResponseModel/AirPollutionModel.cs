using Newtonsoft.Json.Linq;

namespace WeatherAPI.ResponseModel
{
    public class AirPollutionModel
    {
        public int Aqi { get; set; }
        public double Co { get; set; }
        public double No { get; set; }
        public double No2 { get; set; }
        public double O3 { get; set; }
        public double So2 { get; set; }
        public double Pm2_5 { get; set; }
        public double Pm10 { get; set; }
        public double Nh3 { get; set; }

        public static AirPollutionModel ParseAirPollution(string json)
        {
            var root = JObject.Parse(json);
            var listItem = root["list"]?[0]??throw new Exception("No air pollution data found");

            return new AirPollutionModel
            {
                Aqi = listItem["main"]?["aqi"]?.ToObject<int>() ?? 0,
                Co = listItem["components"]?["co"]?.ToObject<double>() ?? 0,
                No = listItem["components"]?["no"]?.ToObject<double>() ?? 0,
                No2 = listItem["components"]?["no2"]?.ToObject<double>() ?? 0,
                O3 = listItem["components"]?["o3"]?.ToObject<double>() ?? 0,
                So2 = listItem["components"]?["so2"]?.ToObject<double>() ?? 0,
                Pm2_5 = listItem["components"]?["pm2_5"]?.ToObject<double>() ?? 0,
                Pm10 = listItem["components"]?["pm10"]?.ToObject<double>() ?? 0,
                Nh3 = listItem["components"]?["nh3"]?.ToObject<double>() ?? 0
            };
        }

    }
}
