using HMS.DAL.Context;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.BLL.Extensions
{
    public static class SQLConnExtension
    {
        public static void AddDatabaseConnection(this IServiceCollection services)
        {
            IConfiguration config;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                config = serviceProvider.GetService<IConfiguration>();
            }
            string cc = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<HmoDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>()
                  .AddEntityFrameworkStores<HmoDbContext>()
                  .AddDefaultTokenProviders();

        }
    }
}
