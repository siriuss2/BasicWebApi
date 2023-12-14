namespace BasicWebApi.DataAccess.Repositories.Interfaces
{
    using BasicWebApi.Domain.Domain;
    public interface IContactRepository : IRepository<Contact>
    {
        Task<List<Contact>> FilterContact(int? countryId, int? companyId);
    }
}
