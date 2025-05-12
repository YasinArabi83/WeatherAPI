using WeatherAPI.Interfaces;

namespace WeatherAPI.Services
{
    public class ApiFetcher : IApiFetcher
    {
        public async Task<string> GetApis(HttpClient client, string endpoint)
        {
            var respons = await client.GetAsync(endpoint);
            respons.EnsureSuccessStatusCode();
            return await respons.Content.ReadAsStringAsync();
        }
    }
}
