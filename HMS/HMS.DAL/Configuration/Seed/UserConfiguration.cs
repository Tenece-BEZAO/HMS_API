using HMS.DAL.Entities;
using HMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.DAL.Configuration.Seed
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
       /* private readonly UserManager<AppUser> _userManager;

        public UserConfiguration()
        {
            
        }*/

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData
            (
                new AppUser
                {
                    UserName = "maraxhi",
                    FirstName = "Amarachi",
                    LastName = "Izuegbu",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                    DateOfBirth = DateTime.Now,
                    Gender = Gender.Female,
                    PhoneNumber = "07038730732",
                    PasswordHash = "@Amara123",
                    Email = "admin@gmail.com"
                }

            );
        }


/*        public async Task SeedAdminRole()
        {
            var adminUser = await _userManager.FindByEmailAsync("admin@gmail.com");

            if (adminUser != null)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }*/
    }

}
