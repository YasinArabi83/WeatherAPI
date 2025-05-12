namespace WeatherAPI.Interfaces
{
    public interface IApiFetcher
    {
        Task<string> GetApis(HttpClient client , string endpoint);
    }
}
