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
            //

            
            modelBuilder.Entity<AppUser>(e =>
            {
                e.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();
                e.HasIndex(u => u.Email)
                 .IsUnique();
            });



            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
