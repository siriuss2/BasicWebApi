namespace BasicWebApi.DTOs.CountryDTOs
{
    public class CreateCountryDTO
    {
        public string CountryName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
