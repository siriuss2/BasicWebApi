namespace BasicWebApi.Domain.Domain
{
    public class Contact : BaseEntity
    {
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
