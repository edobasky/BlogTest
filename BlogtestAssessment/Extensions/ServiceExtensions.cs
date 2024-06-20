using BlogtestAssessment.Data;
using BlogtestAssessment.Repository.Implementations;
using BlogtestAssessment.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogtestAssessment.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlite(this IServiceCollection services, IConfiguration config) =>
            services.AddDbContext<BlogDBContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultTestConnection")));

        public static void ConfigureRepositoryUnitofWork(this IServiceCollection services) =>
            services.AddScoped<IRepositoryUnitofWork, RepositoryUnitofWork>();
    }
}
