namespace BasicWebApi.DTOs.ContactDTOs
{
    public class EditContactDTO
    {
        public int Id { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
