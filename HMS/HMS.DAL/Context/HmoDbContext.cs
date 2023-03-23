﻿using HMS.DAL.Entities;
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
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<AppUser>(e =>
            {
                e.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Email field is required");
                e.HasIndex(u => u.Email, "IX_UniqueEmail")
                 .IsUnique();
            });

            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Username field is required");

            modelBuilder.Entity<AppUser>()
                .Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Firstname field is required");

            modelBuilder.Entity<AppUser>()
                .Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired()
                .HasAnnotation("ErrorMessage", "Lastname field is required");

            modelBuilder.Entity<AppUser>()
                .Property(u => u.MiddleName)
                .HasMaxLength(100)
                .IsRequired(false);

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
        }
    }
}
