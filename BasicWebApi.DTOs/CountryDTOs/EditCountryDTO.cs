namespace BasicWebApi.DTOs.CountryDTOs
{
    public class EditCountryDTO
    {
        public int Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
