using HMS.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Extensions
{
    public static class AdminSeed
    {

        public static void ConfigureSuperAdmin(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            AdminSeed.SeedSuperAdminAsync(userManager);
        }

        public static async Task SeedSuperAdminAsync(UserManager<AppUser> userManager)
        {
            var superAdminUserName = "superadmin";
            var superAdminEmail = "superadmin@hms.com";
            var superAdminPassword = "P@ssword2023";

            var superAdminUser = new AppUser
            {
                UserName = superAdminUserName,
                Email = superAdminEmail,
                EmailConfirmed = true
            };

            var user = userManager.FindByNameAsync(superAdminUserName);
            if (user == null)
            {
                var result = await userManager.CreateAsync(superAdminUser, superAdminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                }
            }
        }
    }
}
