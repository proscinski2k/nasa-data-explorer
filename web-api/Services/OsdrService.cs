using web_api.Interfaces;
using web_api.Models;

namespace web_api.Services
{
    public class OsdrService : IOsdrService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public OsdrService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<OsdrService> logger)
        {
            _httpClient = httpClient;
            _baseUrl = $"{configuration["NasaApi:OsdrBaseUrl"]}/vehicles";
        }

        public async Task<VehiclesResponse> GetVehiclesAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<VehiclesResponse>();
         }

        public async Task<VehicleDetails> GetVehicleByUrlAsync(string metadataUrl)
        {
            var response = await _httpClient.GetAsync(metadataUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<VehicleDetails>();
        }

        public async Task<MissionDetails> GetMissionByUrlAsync(string metadataUrl)
        {
            var response = await _httpClient.GetAsync(metadataUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MissionDetails>();
         }
    }
}
