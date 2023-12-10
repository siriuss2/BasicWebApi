namespace BasicWebApi.Domain.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Contact : BaseEntity
    {
        public string ContactName { get; set; } = string.Empty;

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
