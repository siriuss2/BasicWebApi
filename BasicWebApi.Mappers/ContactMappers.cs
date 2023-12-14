namespace BasicWebApi.Mappers
{
    using BasicWebApi.Domain.Domain;
    using BasicWebApi.DTOs.ContactDTOs;

    public static class ContactMappers
    {
        public static ContactDTO ToContactDTO(this Contact contact)
        {
            return new ContactDTO()
            {
                Id = contact.Id,
                ContactName = contact.ContactName,
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId
            };
        }

        public static Contact ToContact(this CreateContactDTO createContactDTO)
        {
            return new Contact()
            {
                CountryId = createContactDTO.CountryId,
                CompanyId = createContactDTO.CompanyId,
                ContactName = createContactDTO.ContactName
            };
        }
    }
}
