using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.DAL.Configuration.RepoConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
             new IdentityRole
             {
                 Name = "Admin",
                 NormalizedName = "Admin"
             },
             new IdentityRole
             {
                 Name = "Enrolle",
                 NormalizedName = "Enrolle"
             }
         );
        }
    }
}
