namespace BasicWebApi.Domain.Domain
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;
        public List<Country> Countries { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
