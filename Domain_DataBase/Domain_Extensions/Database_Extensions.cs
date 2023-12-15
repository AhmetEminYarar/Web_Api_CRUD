using Domain_DataBase.Domain_Context;
using Domain_DataBase.Domain_Repository;
using Domain_DataBase.Domain_UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain_DataBase.Domain_Extensions
{
    public static class Database_Extensions
    {
        public static IServiceCollection LoadDatabaseExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(i => i.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

    }
}
