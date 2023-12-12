namespace BasicWebApi.Mappers
{
    using BasicWebApi.Domain.Domain;
    using BasicWebApi.DTOs.CountryDTOs;

    public static class CountryMappers
    {
        public static CountryDTO ToCountryDTO(this Country country)
        {
            return new CountryDTO()
            {
                Id = country.Id,
                CompanyId = country.CompanyId,
                CountryName = country.CountryName
            };
        }

        public static Country ToCountry(this CreateCountryDTO createCountryDTO)
        {
            return new Country()
            {
                CountryName = createCountryDTO.CountryName,
                CompanyId = createCountryDTO.CompanyId
            };
        }
    }
}
