namespace BasicWebApi.Helpers
{
    using BasicWebApi.DataAccess;
    using BasicWebApi.DataAccess.Repositories.Implementations;
    using BasicWebApi.DataAccess.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BasicWebApiDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            //services.AddTransient<ICompanyRepository, CompanyRepository>();
        }
    }
}
