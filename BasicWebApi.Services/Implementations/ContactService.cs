namespace BasicWebApi.Services.Implementations
{
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using BasicWebApi.Domain.Domain;
    using BasicWebApi.DTOs.ContactDTOs;
    using BasicWebApi.Mappers;
    using BasicWebApi.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository _contactRepository)
        {
            this._contactRepository = _contactRepository;
        }
        public async Task<List<ContactDTO>> GetAllContactsAsync()
        {
            List<Contact> contactDb = await _contactRepository.GetAllAsync();

            if (contactDb == null)
                throw new Exception("Countries not found.Contact the support team");

            return contactDb.Select(x => x.ToContactDTO()).ToList();
        }
        public async Task<ContactDTO> GetContactByIdAsync(int id)
        {
            Contact contactDb = await _contactRepository.GetByIdAsync(id);

            if(contactDb == null)
                throw new Exception("Country not found.Contact the support team");

            return contactDb.ToContactDTO();
        }
        public async Task<int> CreateContactAsync(CreateContactDTO createContactDTO)
        {
            Contact contactDb = createContactDTO.ToContact();
            await _contactRepository.CreateAsync(contactDb);

            return contactDb.Id;
        }
        public async Task EditContactAsync(EditContactDTO editContactDTO)
        {
            Contact contactDb = await _contactRepository.GetByIdAsync(editContactDTO.Id);

            if(contactDb == null)
                throw new Exception("The contact can not be found.Contact the support team!");

            contactDb.ContactName = editContactDTO.ContactName;
            contactDb.CompanyId = editContactDTO.CompanyId;
            contactDb.CountryId = editContactDTO.CountryId;

            await _contactRepository.UpdateAsync(contactDb);
        }
        public async Task DeleteContactAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }
        public async Task<List<ContactWithCompanyAndCountryDTO>> FilterContacts(int? countryId, int? companyId)
        {
            List<Contact> contactsDb = await _contactRepository.FilterContact(countryId, companyId);

            return contactsDb.Select(contact => new ContactWithCompanyAndCountryDTO
            {
                ContactName = contact.ContactName,
                CompanyName = contact.Company.CompanyName,
                CountryName = contact.Country.CountryName
            }).ToList();
        }
    }
}
