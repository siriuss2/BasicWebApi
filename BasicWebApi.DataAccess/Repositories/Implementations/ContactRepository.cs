namespace BasicWebApi.DataAccess.Repositories.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using Microsoft.EntityFrameworkCore;

    public class ContactRepository : IContactRepository
    {
        private readonly BasicWebApiDbContext _dbContext;

        public ContactRepository(BasicWebApiDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<Contact>> GetAllAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> CreateAsync(Contact entity)
        {
            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Contact> UpdateAsync(Contact entity)
        {
            _dbContext.Contacts.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            Contact contactDb = await _dbContext.Contacts.SingleOrDefaultAsync(x => x.Id == id);

            if (contactDb == null)
                throw new Exception($"Contact with id:{id} not found!");

            _dbContext.Contacts.Remove(contactDb);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Contact>> FilterContact(int? countryId, int? companyId)
        {
            List<Contact> contactsDb = await _dbContext.Contacts
                                         .Include(x => x.Company)
                                         .Include(x => x.Country)
                                         .ToListAsync();

            if (countryId.HasValue)
                contactsDb = contactsDb.Where(c => c.CountryId == countryId.Value).ToList();

            if (companyId.HasValue)
                contactsDb = contactsDb.Where(c => c.CompanyId == companyId.Value).ToList();

            return contactsDb;
        }
    }
}
