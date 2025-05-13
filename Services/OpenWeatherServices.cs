using Microsoft.AspNetCore.WebUtilities;
using WeatherAPI.Interfaces;
using WeatherAPI.ResponseModel;

namespace WeatherAPI.Services;

public class OpenWeatherServices
    (IApiFetcher fetch, ILogger<OpenWeatherServices> logger, HttpClient client, IConfiguration configuration)
    : IOpenWeatherServices
{
    private readonly IApiFetcher _fetch = fetch;
    private readonly ILogger<OpenWeatherServices> _logger = logger;
    private readonly HttpClient _client = client;
    private readonly IConfiguration _configuration = configuration;

    public Task<AirPollutionModel> GetAirPollutionInfo(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }

    public async Task<CityModel> GetCityInfo(string cityName)
    {
        string endPoint = "geo/1.0/direct";
        try
        {
            var queryParams = new Dictionary<string, string?>
            {
                ["q"] = cityName,
                ["appid"] = _configuration["Token"] ?? throw new NullReferenceException("API token is missing in the configuration. Please ensure the 'Token' key is set in the tokens.json file."),
            };

            var urlWithQuery = QueryHelpers.AddQueryString(endPoint, queryParams);

            _logger.LogInformation("Fetching city information for {CityName} from endpoint {Url}", cityName, urlWithQuery);

            var response = await _fetch.GetApis(_client, urlWithQuery);

            var cityInfo = CityModel.ParseCities(response).FirstOrDefault();

            _logger.LogInformation("Successfully retrieved city information for {CityName}", cityName);
            return cityInfo??throw new Exception("City information is null");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request error while fetching city information for {CityName}", cityName);
            throw new Exception("An error occurred while making the HTTP request.", ex);
        }
        catch (NullReferenceException ex)
        {
            _logger.LogError(ex, "Configuration error: {Message}", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while fetching city information for {CityName}", cityName);
            throw;
        }
    }

    public Task<WeatherModel> GetWeatherInfo(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }
}
