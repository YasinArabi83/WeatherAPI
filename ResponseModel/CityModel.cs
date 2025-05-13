using Newtonsoft.Json.Linq;

namespace WeatherAPI.ResponseModel
{
    public class CityModel
    {
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? Name { get; set; }
        public string? NameInFarsi { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public static List<CityModel> ParseCities(string json)
        {
            var jArray = JArray.Parse(json);
            var cities = new List<CityModel>();

            foreach (var item in jArray)
            {
                var city = new CityModel
                {
                    Country = item["country"]?.ToString(),
                    Province = item["state"]?.ToString(),
                    Name = item["name"]?.ToString(),
                    NameInFarsi = item["local_names"]?["fa"]?.ToString(),
                    Latitude = item["lat"]?.ToObject<double>() ?? 0,
                    Longitude = item["lon"]?.ToObject<double>() ?? 0
                };

                cities.Add(city);
            }

            return cities;
        }
    }
}
