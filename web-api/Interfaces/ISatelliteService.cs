using Microsoft.OpenApi.Any;
using web_api.Models;

namespace web_api.Interfaces
{
    public interface ISatelliteService
    {
        Task<SatelliteSearchResponse> GetSatelliteNamesAsync();
        Task<SatelliteSearchResponse> GetSatelliteByNameAsync(string name);
    }
}
