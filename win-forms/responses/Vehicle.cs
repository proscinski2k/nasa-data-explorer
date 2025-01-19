using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win_forms.responses
{

    public class VehicleItem
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class VehicleDetails
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string identifierLowercase { get; set; }
        public string esId { get; set; }
        public List<object> files { get; set; } = new List<object>();
        public DocumentVersion versionInfo { get; set; }
        public VehicleMissions parents { get; set; }
    }

    public class VehicleListItem
    {
        public string vehicle { get; set; }
    }

    public class VehiclesResponse
    {
        public List<VehicleListItem> data { get; set; } = new List<VehicleListItem>();
    }

    public class VehicleReference
    {
        public string vehicle { get; set; }
    }

    public class DocumentVersion
    {
        public string documentKey { get; set; }
        public int version { get; set; }
        public bool deleted { get; set; }
    }

    public class MissionReference
    {
        public string mission { get; set; }
    }

    public class VehicleMissions
    {
        public List<MissionReference> mission { get; set; } = new List<MissionReference>();
    }

    public class MissionDetails
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string identifierLowercase { get; set; }
        public string esId { get; set; }
        public List<string> aliases { get; set; } = new List<string>();
        public string startDate { get; set; }
        public string endDate { get; set; }
        public List<object> files { get; set; } = new List<object>();
        public VehicleReference vehicle { get; set; }
        public List<MissionCrewMember> people { get; set; } = new List<MissionCrewMember>();
        public DocumentVersion versionInfo { get; set; }
        public MissionRelations parents { get; set; }
    }


    public class MissionCrewMember
    {
        public string institution { get; set; }
        public List<string> roles { get; set; } = new List<string>();
        public PersonDetails person { get; set; }
    }

    public class PersonDetails
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public DocumentVersion versionInfo { get; set; }
    }


    public class PayloadReference
    {
        public string payload { get; set; }
    }

    public class MissionRelations
    {
        public List<PayloadReference> payload { get; set; } = new List<PayloadReference>();
        public List<object> experiment { get; set; } = new List<object>();
        public List<object> gldsStudy { get; set; } = new List<object>();
    }


}
