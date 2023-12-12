namespace BasicWebApi.Mappers
{
    using BasicWebApi.Domain.Domain;
    using BasicWebApi.DTOs.CompanyDTOs;

    public static class CompanyMappers
    {
        public static CompanyDTO ToCompanyDTO(this Company company)
        {
            return new CompanyDTO()
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
        }

        public static Company ToCompany(this CreateCompanyDTO createCompanyDTO)
        {
            return new Company()
            {
                CompanyName = createCompanyDTO.CompanyName  
            };
        }
    }
}
