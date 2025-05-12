using WeatherAPI.Interfaces;
using WeatherAPI.ResponseModel;

namespace WeatherAPI.Services;

public class OpenWeatherServices(ApiFetcher fetch, ILogger<OpenWeatherServices> logger, HttpClient client) : IOpenWeatherServices
{
    private readonly ApiFetcher _fetch = fetch;
    private readonly ILogger<OpenWeatherServices> _logger = logger;
    private readonly HttpClient _client=client;

    public Task<AirPollutionModel> GetAirPollutionInfo(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }

    public Task<CityModel> GetCityInfo(string cityName)
    {
        throw new NotImplementedException();
    }

    public Task<WeatherModel> GetWeatherInfo(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }
}
