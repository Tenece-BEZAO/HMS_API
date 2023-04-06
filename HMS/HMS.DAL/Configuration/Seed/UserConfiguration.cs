using HMS.DAL.Entities;
using HMS.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                FirstName = "Bello",
                LastName = "Soliu",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "07038730732",
                PasswordHash = "@Bello123",
                Email = "bellos@gmail.com",

            },
            new AppUser
            {
                UserName = "Caleb",
                FirstName = "Caleb",
                LastName = "Okechi",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "07038730732",
                PasswordHash = "@Caleb123",
                Email = "caleb@gmail.com"
            },
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
                 Email = "amara@gmail.com"
             }
            );
        }
    }
}
