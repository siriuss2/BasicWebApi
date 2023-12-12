namespace BasicWebApi.Services.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using BasicWebApi.DTOs.CompanyDTOs;
    using BasicWebApi.Mappers;
    using BasicWebApi.Services.Interfaces;
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository _companyRepository)
        {
            this._companyRepository = _companyRepository;
        }
        public async Task<List<CompanyDTO>> GetAllCompaniesAsync()
        {
            List<Company> companyDb = await _companyRepository.GetAllAsync();

            if (companyDb == null)
                throw new Exception("Companies not found.Contact the support team");

            return companyDb.Select(x => x.ToCompanyDTO()).ToList();
        }
        public async Task<CompanyDTO> GetCompanyByIdAsync(int id)
        {
            Company companyDb = await _companyRepository.GetByIdAsync(id);

            if (companyDb == null)
                throw new Exception("Company not found.Contact the support team");

            return companyDb.ToCompanyDTO();
        }
        public async Task<int> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO)
        {
            Company companyDb = createCompanyDTO.ToCompany();
            await _companyRepository.CreateAsync(companyDb);

            return companyDb.Id;
        }
        public async Task EditCompanyAsync(EditCompanyDTO editCompanyDTO)
        {
            Company companyDb = await _companyRepository.GetByIdAsync(editCompanyDTO.Id);

            if (companyDb == null)
                throw new Exception("The company can not be found.Contact the support team!");

            companyDb.CompanyName = editCompanyDTO.CompanyName;

            await _companyRepository.UpdateAsync(companyDb);
        }
        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}
