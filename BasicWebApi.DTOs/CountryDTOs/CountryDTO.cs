namespace BasicWebApi.DTOs.CountryDTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
