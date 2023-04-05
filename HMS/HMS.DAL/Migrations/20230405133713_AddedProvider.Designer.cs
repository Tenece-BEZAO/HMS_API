﻿// <auto-generated />
using System;
using HMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMS.DAL.Migrations
{
    [DbContext(typeof(HmoDbContext))]
    [Migration("20230405133713_AddedProvider")]
    partial class AddedProvider
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HMS.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnrolleeId")
                        .HasColumnType("int");

                    b.Property<string>("EnrolleeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasAnnotation("ErrorMessage", "Reason field is required");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnrolleeId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HMS.DAL.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasAnnotation("ErrorMessage", "Email field is required");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("EnrolleeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EnrolleeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProviderId");

                    b.HasIndex(new[] { "Email" }, "IX_UniqueEmail")
                        .IsUnique();

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "40987c42-b29d-4eff-a3dc-2fe5d7389b64",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "491cf6b2-ecaa-472f-8ecd-9402ce5d639a",
                            DateOfBirth = new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2684),
                            Email = "bellos@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Bello",
                            Gender = 0,
                            LastName = "Soliu",
                            LockoutEnabled = false,
                            PasswordHash = "@Bello123",
                            PhoneNumber = "07038730732",
                            PhoneNumberConfirmed = false,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "51ccddfd-3e51-459c-a2d6-c99c7ae4b0f7",
                            TwoFactorEnabled = false,
                            UserName = "SobTech"
                        },
                        new
                        {
                            Id = "0be87530-3828-48d2-8681-eb5699055936",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "3cacf6a4-091b-40fb-9819-daff4a483c0a",
                            DateOfBirth = new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2706),
                            Email = "caleb@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Caleb",
                            Gender = 0,
                            LastName = "Okechi",
                            LockoutEnabled = false,
                            PasswordHash = "@Caleb123",
                            PhoneNumber = "07038730732",
                            PhoneNumberConfirmed = false,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "1ad1a83a-260b-4531-ade1-40be40fa90e0",
                            TwoFactorEnabled = false,
                            UserName = "Caleb"
                        },
                        new
                        {
                            Id = "dab77144-35fa-4fe8-a676-e4deeeccbdc1",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "baaefa5c-0de1-4484-ba83-6d81eb997d3c",
                            DateOfBirth = new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2715),
                            Email = "amara@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Amarachi",
                            Gender = 1,
                            LastName = "Izuegbu",
                            LockoutEnabled = false,
                            PasswordHash = "@Amara123",
                            PhoneNumber = "07038730732",
                            PhoneNumberConfirmed = false,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "43d05bee-ca4c-4939-9526-57d5d2187b3d",
                            TwoFactorEnabled = false,
                            UserName = "maraxhi"
                        });
                });

            modelBuilder.Entity("HMS.DAL.Entities.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ErrorMessage", "Name field is required");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasAnnotation("ErrorMessage", "Price field is required");

                    b.HasKey("Id");

                    b.HasIndex("PlanId")
                        .IsUnique();

                    b.ToTable("Drug");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Enrollee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanId")
                        .IsUnique()
                        .HasFilter("[PlanId] IS NOT NULL");

                    b.ToTable("Enrollee");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ErrorMessage", "Name field is required");

                    b.Property<int>("PlanType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasAnnotation("ErrorMessage", "Price field is required");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<int?>("EnrolleId")
                        .HasColumnType("int");

                    b.Property<int?>("EnrolleeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.HasIndex("EnrolleeId");

                    b.HasIndex("PlanId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7120e2b5-de12-4ff7-ad75-ea7222c94a91",
                            ConcurrencyStamp = "fbb23154-fe09-4a52-b05d-4d8a5e479a85",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "44e0fcdb-9fc6-49e5-9b72-6522ffa439e0",
                            ConcurrencyStamp = "f86f66cd-9bf3-4e0f-9d72-ebe578329636",
                            Name = "Enrollee",
                            NormalizedName = "ENROLLEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HMS.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Enrollee", "Enrollee")
                        .WithMany()
                        .HasForeignKey("EnrolleeId");

                    b.HasOne("HMS.DAL.Entities.Provider", "Provider")
                        .WithMany("Appointments")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Enrollee");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("HMS.DAL.Entities.AppUser", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Enrollee", "Enrollee")
                        .WithMany()
                        .HasForeignKey("EnrolleeId");

                    b.HasOne("HMS.DAL.Entities.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.Navigation("Enrollee");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Drug", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Plan", "Plan")
                        .WithOne("Drug")
                        .HasForeignKey("HMS.DAL.Entities.Drug", "PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Enrollee", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Plan", "Plan")
                        .WithOne("Enrollee")
                        .HasForeignKey("HMS.DAL.Entities.Enrollee", "PlanId");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Report", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId");

                    b.HasOne("HMS.DAL.Entities.Enrollee", "Enrollee")
                        .WithMany()
                        .HasForeignKey("EnrolleeId");

                    b.HasOne("HMS.DAL.Entities.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("HMS.DAL.Entities.Provider", "provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.Navigation("Drug");

                    b.Navigation("Enrollee");

                    b.Navigation("Plan");

                    b.Navigation("provider");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HMS.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HMS.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HMS.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HMS.DAL.Entities.Plan", b =>
                {
                    b.Navigation("Drug")
                        .IsRequired();

                    b.Navigation("Enrollee")
                        .IsRequired();
                });

            modelBuilder.Entity("HMS.DAL.Entities.Provider", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
