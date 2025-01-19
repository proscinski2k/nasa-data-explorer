namespace web_api.Models
{
    public class MissionDetails
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string IdentifierLowercase { get; set; }
        public string EsId { get; set; }
        public List<string> Aliases { get; set; } = new List<string>();
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<object> Files { get; set; } = new List<object>();
        public VehicleReference Vehicle { get; set; }
        public List<MissionCrewMember> People { get; set; } = new List<MissionCrewMember>();
        public DocumentVersion VersionInfo { get; set; }
        public MissionRelations Parents { get; set; }
    }


    public class MissionCrewMember
    {
        public string Institution { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public PersonDetails Person { get; set; }
    }
}
