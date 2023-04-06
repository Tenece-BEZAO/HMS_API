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
    [Migration("20230327144421_initialMig")]
    partial class initialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = "6b53480f-f539-43c8-8e2d-e0cb539390a1",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "08129a8a-c5da-4e7d-bba7-4211175f265a",
                            DateOfBirth = new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9261),
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
                            SecurityStamp = "853d550c-ca40-4481-84d7-ba9bd10e5bcb",
                            TwoFactorEnabled = false,
                            UserName = "SobTech"
                        },
                        new
                        {
                            Id = "e548b05d-e04a-4c7e-94d1-5b2beeb71f4c",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "f92bced5-88b6-435a-8f0d-7ef5f9bb6842",
                            DateOfBirth = new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9311),
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
                            SecurityStamp = "c03fc242-cabd-4f0b-a51f-ac6a227ffa53",
                            TwoFactorEnabled = false,
                            UserName = "Caleb"
                        },
                        new
                        {
                            Id = "de779f82-456e-462b-a225-2310746243a7",
                            AccessFailedCount = 0,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            ConcurrencyStamp = "831feb3a-5189-4b81-a0a6-42199bacb130",
                            DateOfBirth = new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9322),
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
                            SecurityStamp = "1ee773bf-d8df-4de7-b3b5-34406e0dbe4a",
                            TwoFactorEnabled = false,
                            UserName = "maraxhi"
                        });
                });

            modelBuilder.Entity("HMS.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnrolleId")
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

                    b.HasIndex("ProviderId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AppointmentId")
                        .IsUnique()
                        .HasFilter("[AppointmentId] IS NOT NULL");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<int?>("EnrolleId")
                        .HasColumnType("int");

                    b.Property<int>("Enrolleeid")
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

                    b.HasIndex("AppUserId1");

                    b.HasIndex("DrugId");

                    b.HasIndex("Enrolleeid");

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
                            Id = "300c75f2-88d7-4a86-996d-189c46f8c5f5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "7fa67ff7-2c53-48c2-bf21-d97db66f7cd3",
                            Name = "Enrollee",
                            NormalizedName = "ENROLLEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("HMS.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("HMS.DAL.Entities.Provider", "provider")
                        .WithMany("Appointment")
                        .HasForeignKey("ProviderId");

                    b.Navigation("provider");
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
                    b.HasOne("HMS.DAL.Entities.Appointment", "appointment")
                        .WithOne("enrollee")
                        .HasForeignKey("HMS.DAL.Entities.Enrollee", "AppointmentId");

                    b.HasOne("HMS.DAL.Entities.Plan", "Plan")
                        .WithOne("Enrollee")
                        .HasForeignKey("HMS.DAL.Entities.Enrollee", "PlanId");

                    b.Navigation("Plan");

                    b.Navigation("appointment");
                });

            modelBuilder.Entity("HMS.DAL.Entities.Report", b =>
                {
                    b.HasOne("HMS.DAL.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId1");

                    b.HasOne("HMS.DAL.Entities.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId");

                    b.HasOne("HMS.DAL.Entities.Enrollee", "Enrollee")
                        .WithMany()
                        .HasForeignKey("Enrolleeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.DAL.Entities.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("HMS.DAL.Entities.Provider", "provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.Navigation("AppUser");

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

            modelBuilder.Entity("HMS.DAL.Entities.Appointment", b =>
                {
                    b.Navigation("enrollee")
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
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
