namespace BasicWebApi.Domain.Domain
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
