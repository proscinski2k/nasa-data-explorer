using System.Text.Json;
using web_api.Interfaces;
using web_api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_api.Services
{
    public class SatelliteService : ISatelliteService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SatelliteService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = $"{configuration["NasaApi:TleUrl"]}/tle?page-size=100";
            Console.WriteLine(_baseUrl);
        }

        public async Task<SatelliteSearchResponse> GetSatelliteNamesAsync()
        {
            Console.WriteLine(_baseUrl);
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SatelliteSearchResponse>(content) ?? throw new InvalidOperationException("Failed to deserialize Satellite response");
        }

        public async Task<SatelliteSearchResponse> GetSatelliteByNameAsync(string name)
        {
            var url = $"{_baseUrl}&search={name}";
            Console.WriteLine(url);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SatelliteSearchResponse>(content) ?? throw new InvalidOperationException("Failed to deserialize Satellite response");
        }
    }
}
