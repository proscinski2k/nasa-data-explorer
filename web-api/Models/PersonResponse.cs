namespace web_api.Models
{
    public class PersonDetails
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DocumentVersion VersionInfo { get; set; }
    }
}
