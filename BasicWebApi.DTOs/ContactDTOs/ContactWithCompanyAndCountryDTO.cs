namespace BasicWebApi.DTOs.ContactDTOs
{
    public class ContactWithCompanyAndCountryDTO
    {
        public string ContactName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
    }
}
