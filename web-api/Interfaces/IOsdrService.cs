using web_api.Models;

namespace web_api.Interfaces
{
    public interface IOsdrService
    {
        Task<VehiclesResponse> GetVehiclesAsync();
        Task<VehicleDetails> GetVehicleByUrlAsync(string metadataUrl);
        Task<MissionDetails> GetMissionByUrlAsync(string metadataUrl);
    }
}
