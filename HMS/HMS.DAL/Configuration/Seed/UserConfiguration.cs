using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HMS.DAL.Entities;
using HMS.DAL.Enums;

namespace HMS.DAL.Configuration.Seed
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData
            (
            new AppUser
            {
                UserName = "SobTech",
                FullName = "Bello Soliu",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                DateOfBirth =  DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "07038730732",
                PasswordHash = "@Bello123",
                Email = "bello@gmail.com",
                
            },
            new AppUser
            {
                UserName = "Caleb",
                FullName = "Caleb Oke",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "07038730732",
                PasswordHash = "@Caleb123",
                Email = "caleb@gmail.com"
            }
            );
        }
    }
}
