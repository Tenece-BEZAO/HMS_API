using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.DAL.Context
{
    public class HmoDbContext : IdentityDbContext<AppUser>
    {
        public HmoDbContext(DbContextOptions<HmoDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //

            base.OnModelCreating(modelBuilder);
        }
    }
}
