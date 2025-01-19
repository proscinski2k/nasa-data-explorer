namespace web_api.Models
{
    public class SystemInfoResponse
    {
        public bool IsWebApiAvailable { get; set; }
        public bool IsNasaApiAvailable { get; set; }
        public DateTime CheckTime { get; set; }
    }
}
