namespace BasicWebApi.DataAccess.Repositories.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CompanyRepository : ICompanyRepository
    {
        private readonly BasicWebApiDbContext _dbContext;

        public CompanyRepository(BasicWebApiDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }
        public async Task<Company> GetByIdAsync(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> CreateAsync(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Company> UpdateAsync(Company entity)
        {
            _dbContext.Companies.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            Company companyDb = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Id == id);

            if (companyDb == null)
                throw new Exception($"Company with id:{id} not found!");

            _dbContext.Companies.Remove(companyDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}