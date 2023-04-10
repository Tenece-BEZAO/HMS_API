using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEnrolleeEntityTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1b8b914-8fc5-4656-97a2-43b66362e487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebdc9608-2da7-4a26-876c-b252fb1e1f31");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "062c8251-c310-4748-a677-56bdb89fc2ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78247c3c-6733-4475-a7f9-ca83dc46b1bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6c5e139-0082-4501-91b4-9b182f070305");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Enrollees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Enrollees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Enrollees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Enrollees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Enrollees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Enrollees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10e4d8a6-a321-4d14-933f-b74bb63cb69c", null, "Enrollee", "ENROLLEE" },
                    { "ab082b7b-aa3d-43a4-b964-08fd711506cf", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a536736a-c4cf-495f-b857-0667d15deb72", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "ecccbca2-14aa-4eea-ab05-d8f73fbba210", new DateTime(2023, 4, 9, 21, 25, 24, 958, DateTimeKind.Local).AddTicks(8769), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "213e4aeb-b6a6-4b8f-b81e-c9dc09f5ba5b", false, "SobTech" },
                    { "b97992fd-afc9-4282-9e4d-8dbbfc21eb53", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "bc1c2ef1-c830-4950-b54a-aa28365a641c", new DateTime(2023, 4, 9, 21, 25, 24, 958, DateTimeKind.Local).AddTicks(8943), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cd3e90eb-006e-4b78-93ac-aa62bc301f72", false, "Caleb" },
                    { "d5cc5a14-a9a7-41b0-984f-b4d76c8921d1", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "93cb6ace-35a7-481e-b7ff-23e9f9304d67", new DateTime(2023, 4, 9, 21, 25, 24, 958, DateTimeKind.Local).AddTicks(9007), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ee4a5b05-1941-4a5d-bc15-074d06dd4675", false, "maraxhi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10e4d8a6-a321-4d14-933f-b74bb63cb69c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab082b7b-aa3d-43a4-b964-08fd711506cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a536736a-c4cf-495f-b857-0667d15deb72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97992fd-afc9-4282-9e4d-8dbbfc21eb53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5cc5a14-a9a7-41b0-984f-b4d76c8921d1");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Enrollees");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Enrollees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Enrollees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Enrollees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Enrollees");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Enrollees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1b8b914-8fc5-4656-97a2-43b66362e487", null, "Enrollee", "ENROLLEE" },
                    { "ebdc9608-2da7-4a26-876c-b252fb1e1f31", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "062c8251-c310-4748-a677-56bdb89fc2ff", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "8faba98d-a0ba-47b9-8995-ea36aadc02e8", new DateTime(2023, 4, 8, 9, 18, 58, 69, DateTimeKind.Local).AddTicks(8653), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "df96e2f3-b737-4a13-827e-e2ee91699d4e", false, "maraxhi" },
                    { "78247c3c-6733-4475-a7f9-ca83dc46b1bb", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "3b78be5e-b2e9-4b66-9c02-1cfb87963151", new DateTime(2023, 4, 8, 9, 18, 58, 69, DateTimeKind.Local).AddTicks(8640), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e973a5e9-09c1-48b4-a87e-06dee1b960ad", false, "Caleb" },
                    { "f6c5e139-0082-4501-91b4-9b182f070305", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "fa3440cc-7694-419f-b73e-1109d038ef54", new DateTime(2023, 4, 8, 9, 18, 58, 69, DateTimeKind.Local).AddTicks(8601), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "896485af-3627-44d1-a219-0fb4ee9283f8", false, "SobTech" }
                });
        }
    }
}
