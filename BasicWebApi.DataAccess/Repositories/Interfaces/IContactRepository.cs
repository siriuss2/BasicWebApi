namespace BasicWebApi.DataAccess.Repositories.Interfaces
{
    using BasicWebApi.Domain.Domain;
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Contact> GetContactsWithCompanyAndCountry();
        Task<List<Contact>> FilterContact(int? countryId, int? companyId);
    }
}
