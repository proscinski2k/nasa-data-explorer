using System.Text.Json;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Services
{
    public class ApodService : IApodService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public ApodService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["NasaApi:Key"];
            //&date=2024-01-01
            _baseUrl = $"{configuration["NasaApi:BaseUrl"]}/planetary/apod?api_key={_apiKey}";
        }

        public async Task<ApodResponse> GetApodDataAsync(string date)
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApodResponse>(content) ?? throw new InvalidOperationException("Failed to deserialize APOD response"); 
        }
    }
}
