namespace BasicWebApi.DTOs.ContactDTOs
{
    using BasicWebApi.Domain.Domain;

    public class ContactDTO
    {
        public int Id { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
    }
}
