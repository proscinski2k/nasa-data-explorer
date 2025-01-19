using web_api.Models;

namespace web_api.Interfaces
{
    public interface IApodService
    {
        Task<ApodResponse> GetApodDataAsync(string date);
    }
}
