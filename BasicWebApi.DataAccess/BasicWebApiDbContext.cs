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

            modelBuilder.Entity<Country>()
                .Property(x => x.CountryName)
                .HasMaxLength(30);

            modelBuilder.Entity<Company>()
                .Property(x => x.CompanyName)
                .HasMaxLength(30);

            modelBuilder.Entity<Contact>()
                .Property(x => x.ContactName)
                .HasMaxLength(30);

            modelBuilder.Entity<Contact>()
                .HasOne(x => x.Company)
                .WithOne()
                .HasForeignKey<Contact>(x => x.CompanyId);

            modelBuilder.Entity<Contact>()
                .HasOne(x => x.Country)
                .WithOne()
                .HasForeignKey<Contact>(x => x.CountryId);
        }
    }
}
