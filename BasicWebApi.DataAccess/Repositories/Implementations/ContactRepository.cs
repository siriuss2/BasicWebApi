namespace BasicWebApi.DataAccess.Repositories.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    public class ContactRepository : IContactRepository
    {
        public Task<int> CreateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> FilterContact(int? countryId, int? companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactsWithCompanyAndCountry()
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
