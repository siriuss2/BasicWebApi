namespace BasicWebApi.Services.Interfaces
{
    using BasicWebApi.DTOs.CountryDTOs;

    public interface ICountryService
    {
        Task<List<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryByIdAsync(int id);
        Task<int> CreateCountryAsync(CreateCountryDTO createCountryDTO);
        Task EditCountryAsync(EditCountryDTO editCountryDTO);
        Task DeleteCountryAsync(int id);
    }
}
