using Microsoft.AspNetCore.SignalR;
using WeatherAPI.ResponseModel;

namespace WeatherAPI.Interfaces
{
    public interface IOpenWeatherServices
    {
        Task<CityModel> GetCityInfo(string cityName);
        Task<WeatherModel> GetWeatherInfo(double latitude, double longitude);
        Task<AirPollutionModel> GetAirPollutionInfo(double latitude, double longitude);
    }
}
