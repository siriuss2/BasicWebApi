namespace BasicWebApi.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
