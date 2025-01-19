using web_api.Models;

namespace web_api.Interfaces
{
    public interface ISystemService
    {
        Task<SystemInfoResponse> CheckSystemAvailabilityAsync();
        SystemVersionResponse GetSystemVersion();
    }

}
