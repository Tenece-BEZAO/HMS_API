using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPlanEnrolleeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees");

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
                    { "28dd6d31-def5-4302-ac30-e621866181b6", null, "Enrollee", "ENROLLEE" },
                    { "46736562-183e-4f95-a193-f11002343bd6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3bb1829a-ae6b-432f-be11-ffaf1ba32e05", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "b95e283a-0c7f-405f-8252-cd3a078e5c88", new DateTime(2023, 4, 11, 21, 58, 45, 417, DateTimeKind.Local).AddTicks(4096), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3ee5a3f5-6a94-471f-b76e-c5e4ec66ec82", false, "SobTech" },
                    { "3f311074-47e3-4644-b0b2-7001e260326e", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "0f445174-cbc7-403a-a50c-d8dcef245af8", new DateTime(2023, 4, 11, 21, 58, 45, 417, DateTimeKind.Local).AddTicks(4135), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1c33bd11-7755-4666-b524-0d94f01fae0d", false, "Caleb" },
                    { "62e10b31-551e-4b27-af12-7ef4760fa138", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "89107fde-efee-4162-b6bc-2063300e2e3f", new DateTime(2023, 4, 11, 21, 58, 45, 417, DateTimeKind.Local).AddTicks(4165), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b57b8185-2df1-4b49-9482-29052e095605", false, "maraxhi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28dd6d31-def5-4302-ac30-e621866181b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46736562-183e-4f95-a193-f11002343bd6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bb1829a-ae6b-432f-be11-ffaf1ba32e05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f311074-47e3-4644-b0b2-7001e260326e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62e10b31-551e-4b27-af12-7ef4760fa138");

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");
        }
    }
}
