using HMS.DAL.Context;
using HMS.DAL.Entities;
using HMS.DAL.Enums;
using Microsoft.AspNetCore.Builder;
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

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(9);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Tokens.ProviderMap.Add("Email", new TokenProviderDescriptor(
                    typeof(EmailTokenProvider<AppUser>)));
            })
                  .AddEntityFrameworkStores<HmoDbContext>()
                  .AddDefaultTokenProviders()
                  .AddTokenProvider<EmailTokenProvider<AppUser>>("Email");

        }

        public static async Task SeedRoleAsync(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var superAdminUser = new AppUser
            {
                UserName = "Hmsteam",
                FirstName = "HMS",
                LastName = "Project",
                Address = "geneys tech hub",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "07038730732",
                PasswordHash = "P@ssword2023",
                Email = "superadmin@gmail.com",
                EmailConfirmed = false
            };


            var user = await userManager.FindByNameAsync("HmsTeam");
            if (user == null)
            {
                var result = await userManager.CreateAsync(superAdminUser, "P@ssword2023");
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("SuperAdmin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                    }
                    await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                }
            }
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }

        }


    }
}
