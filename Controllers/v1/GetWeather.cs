using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Interfaces;
using WeatherAPI.ResponseModel;
using WeatherAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GetWeather(IOpenWeatherServices weatherServices) : ControllerBase
    {
        private readonly IOpenWeatherServices _weatherServices = weatherServices;

        // GET: api/<ValuesController>
        [HttpGet("by-cityName/{city}")]
        public async Task<ActionResult<WeatherModel>> Get([FromRoute] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name is required.");
            }
            try
            {
                var cityInfo = await _weatherServices.GetCityInfo(city);
                var airPollution = await _weatherServices.GetAirPollutionInfo(cityInfo.Latitude, cityInfo.Longitude);
                var weather = await _weatherServices.GetWeatherInfo(cityInfo.Latitude, cityInfo.Longitude);
                weather.AirPollutionInfo = airPollution;
                weather.LocationInfo = cityInfo;
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("by-location")]
        public async Task<ActionResult<WeatherModel>> Get(
            [FromQuery] double? lat,
            [FromQuery] double? lon)
        {
            if (lat == null || lon == null)
            {
                return BadRequest("Latitude or longitude are required.");
            }
            try
            {
                var weather = await _weatherServices.GetWeatherInfo(lat.Value, lon.Value);
                var airPollution = await _weatherServices.GetAirPollutionInfo(lat.Value, lon.Value);
                weather.AirPollutionInfo = airPollution;
                weather.LocationInfo = new CityModel { Latitude = lat.Value, Longitude = lon.Value };
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }
    }
}
