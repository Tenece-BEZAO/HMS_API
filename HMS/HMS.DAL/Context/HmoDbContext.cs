using HMS.DAL.Configuration.RepoConfiguration;
using HMS.DAL.Configuration.Seed;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.DAL.Context
{
    public class HmoDbContext : IdentityDbContext<AppUser>
    {
        public HmoDbContext(DbContextOptions<HmoDbContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Enrollee> Enrollees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(e =>
            {
                e.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Email field is required");
                e.HasIndex(u => u.Email, "IX_UniqueEmail")
                 .IsUnique();
            });

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Reason)
                .HasMaxLength(1000)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Reason field is required");

            modelBuilder.Entity<Plan>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Name field is required");

            modelBuilder.Entity<Plan>()
                .Property(p => p.Price)
                .HasPrecision(15, 2)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Price field is required");

            modelBuilder.Entity<Drug>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Name field is required");

            modelBuilder.Entity<Drug>()
                .Property(d => d.Description)
                .HasMaxLength(1000)
                .IsRequired(false);


            modelBuilder.Entity<Drug>()
                .Property(d => d.Price)
                .HasPrecision(15, 2)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Price field is required");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
