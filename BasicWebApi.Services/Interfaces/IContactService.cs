namespace BasicWebApi.Services.Interfaces
{
    using BasicWebApi.DTOs.ContactDTOs;

    public interface IContactService
    {
        Task<List<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int id);
        Task<int> CreateContactAsync(CreateContactDTO createContactDTO);
        Task EditContactAsync(EditContactDTO editContactDTO);
        Task DeleteContactAsync(int id);
        Task<List<ContactWithCompanyAndCountryDTO>> FilterContacts(int? countryId, int? companyId);
    }
}
