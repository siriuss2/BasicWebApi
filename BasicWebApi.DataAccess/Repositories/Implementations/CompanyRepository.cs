namespace BasicWebApi.DataAccess.Repositories.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CompanyRepository : ICompanyRepository
    {
        public Task<int> CreateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
