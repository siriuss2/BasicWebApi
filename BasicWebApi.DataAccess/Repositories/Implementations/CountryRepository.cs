﻿namespace BasicWebApi.DataAccess.Repositories.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CountryRepository : ICountryRepository
    {
        private readonly BasicWebApiDbContext _dbContext;

        public CountryRepository(BasicWebApiDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<Country>> GetAllAsync()
        {
            return await _dbContext.Countries.ToListAsync();
        }
        public async Task<Country> GetByIdAsync(int id)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> CreateAsync(Country entity)
        {
            await _dbContext.Countries.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Country> UpdateAsync(Country entity)
        {
            _dbContext.Countries.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            Country countryDb = await _dbContext.Countries.SingleOrDefaultAsync(x => x.Id == id);

            if(countryDb == null)
                throw new Exception($"Country with id:{id} not found!");

            _dbContext.Countries.Remove(countryDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
