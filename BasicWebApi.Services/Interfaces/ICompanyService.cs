namespace BasicWebApi.Services.Interfaces
{
    using BasicWebApi.DTOs.CompanyDTOs;

    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetAllCompaniesAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(int id);
        Task<int> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO);
        Task EditCompanyAsync(EditCompanyDTO editMovieDTO);
        Task DeleteCompanyAsync(int id);
    }
}
