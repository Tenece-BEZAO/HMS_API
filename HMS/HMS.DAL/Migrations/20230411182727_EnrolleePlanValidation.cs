using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EnrolleePlanValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a390b7-cc6e-463b-8fb7-f82944672cc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "749a043f-c042-497c-864b-3289f40c42dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e9579ad-1dc5-4e80-9ad6-faa7b1503429");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a9aa8dc-5df5-4e12-9f97-4c19d7c51cb1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c71f940b-b81d-405d-b557-f71f9114181f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73564baa-8158-47c9-9949-7a68d2d17da3", null, "Enrollee", "ENROLLEE" },
                    { "9a4db530-f736-4036-98b5-c72946d0de12", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2cae0a5a-6fca-450a-a8df-b56b46feacc5", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "e7b765c8-cf9b-479b-9162-39ab46e89d53", new DateTime(2023, 4, 11, 19, 27, 27, 9, DateTimeKind.Local).AddTicks(3601), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "266e3df2-aa59-4205-9ca7-8ec2e9f0277c", false, "SobTech" },
                    { "ea272c5e-777f-4f60-bed4-e85a3f6ed9f9", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "5cb14210-e6ca-4b7b-9853-d8b967c1c7bf", new DateTime(2023, 4, 11, 19, 27, 27, 9, DateTimeKind.Local).AddTicks(3648), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7a961ba-a7ef-4400-aaa0-2d1ebb16a307", false, "maraxhi" },
                    { "ff3a348e-145c-49dd-8af6-6ab523b7a8b0", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "ddc88867-cfc3-4560-a5af-831aa151ef77", new DateTime(2023, 4, 11, 19, 27, 27, 9, DateTimeKind.Local).AddTicks(3629), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "df100c4c-1841-46ce-b821-52b5b77fbc22", false, "Caleb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73564baa-8158-47c9-9949-7a68d2d17da3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a4db530-f736-4036-98b5-c72946d0de12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cae0a5a-6fca-450a-a8df-b56b46feacc5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea272c5e-777f-4f60-bed4-e85a3f6ed9f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff3a348e-145c-49dd-8af6-6ab523b7a8b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57a390b7-cc6e-463b-8fb7-f82944672cc1", null, "Admin", "ADMIN" },
                    { "749a043f-c042-497c-864b-3289f40c42dd", null, "Enrollee", "ENROLLEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e9579ad-1dc5-4e80-9ad6-faa7b1503429", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "0139a1c5-4758-45b7-8f69-397280770e5f", new DateTime(2023, 4, 11, 19, 18, 21, 838, DateTimeKind.Local).AddTicks(5530), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c464aad4-7a30-4728-a544-12f0cfe96d63", false, "Caleb" },
                    { "9a9aa8dc-5df5-4e12-9f97-4c19d7c51cb1", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "a37f5312-a751-47bc-8710-b0e3f335b15f", new DateTime(2023, 4, 11, 19, 18, 21, 838, DateTimeKind.Local).AddTicks(5560), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e28ad00-185d-4ecc-913c-ccb551f91a70", false, "maraxhi" },
                    { "c71f940b-b81d-405d-b557-f71f9114181f", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "066f6af8-12b9-4c79-819f-316dbbcb6d7a", new DateTime(2023, 4, 11, 19, 18, 21, 838, DateTimeKind.Local).AddTicks(5461), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "67eeabdd-83d2-42ab-bc1a-d1a3d78f6bb8", false, "SobTech" }
                });
        }
    }
}
