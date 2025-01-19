namespace web_api.Models
{

 
    public class MissionReference
    {
        public string Mission { get; set; }
    }

    public class VehicleMissions
    {
        public List<MissionReference> Mission { get; set; } = new List<MissionReference>();
    }

    public class DocumentVersion
    {
        public string DocumentKey { get; set; }
        public int Version { get; set; }
        public bool Deleted { get; set; }
    }


    public class PayloadReference
    {
        public string Payload { get; set; }
    }

    public class MissionRelations
    {
        public List<PayloadReference> Payload { get; set; } = new List<PayloadReference>();
        public List<object> Experiment { get; set; } = new List<object>();
        public List<object> GldsStudy { get; set; } = new List<object>();
    }





}
