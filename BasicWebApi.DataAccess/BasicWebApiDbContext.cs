namespace BasicWebApi.DataAccess
{
    using BasicWebApi.Domain.Domain;
    using Microsoft.EntityFrameworkCore;

    public class BasicWebApiDbContext : DbContext
    {
        public BasicWebApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Contacts)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Countries)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<Country>()
                .HasMany(x => x.Contacts)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<Country>()
                .Property(x => x.CountryName)
                .HasMaxLength(30);

            modelBuilder.Entity<Company>()
                .Property(x => x.CompanyName)
                .HasMaxLength(30);

            modelBuilder.Entity<Contact>()
                .Property(x => x.ContactName)
                .HasMaxLength(30);
        }
    }
}
