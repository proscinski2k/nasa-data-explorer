using Microsoft.Extensions.Options;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Services
{
    public class SystemService : ISystemService
    {
        private readonly IConfiguration _configuration;
        private readonly ISatelliteService _satelliteService;
        private readonly HttpClient _httpClient;

        public SystemService(
            IConfiguration configuration,
           ISatelliteService satelliteService,
              HttpClient httpClient
        )
        {
            _configuration = configuration;
            _satelliteService = satelliteService;
            _httpClient = httpClient;
        }

        public async Task<SystemInfoResponse> CheckSystemAvailabilityAsync()
        {
            var systemInfo = new SystemInfoResponse
            {
                IsWebApiAvailable = true,
                IsNasaApiAvailable = true,
                CheckTime = DateTime.UtcNow
            };

            try
            {
                await _satelliteService.GetSatelliteNamesAsync();
            }
            catch
            {
                systemInfo.IsNasaApiAvailable = false;
            }

            return systemInfo;
        }

        public SystemVersionResponse GetSystemVersion()
        {
            return new SystemVersionResponse
            {
                Version = _configuration["Version"],
                Authors = _configuration["Authors"],
                BuildDate = DateTime.UtcNow
            };
        }
    }
}
