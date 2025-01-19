namespace web_api.Models
{


    public class VehicleDetails
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string IdentifierLowercase { get; set; }
        public string EsId { get; set; }
        public List<object> Files { get; set; } = new List<object>();
        public DocumentVersion VersionInfo { get; set; }
        public VehicleMissions Parents { get; set; }
    }

    public class VehicleListItem
    {
        public string Vehicle { get; set; }
    }

    public class VehiclesResponse
    {
        public List<VehicleListItem> Data { get; set; } = new List<VehicleListItem>();
    }

    public class VehicleReference
    {
        public string Vehicle { get; set; }
    }

}
