using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProviderEnrollee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Enrollee_Enrolleeid",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea8e304-3811-4875-9de4-499ead801efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5447774f-fd90-440c-87b6-cd1484ffd7d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14bd3734-1b1b-4a5b-9636-fa2c6a3c4fc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cafd2387-625b-40e7-8b8b-a94f54c3cc89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e33b9058-c761-43ca-8ce9-9080a1706e20");

            migrationBuilder.RenameColumn(
                name: "Enrolleeid",
                table: "Reports",
                newName: "EnrolleeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_Enrolleeid",
                table: "Reports",
                newName: "IX_Reports_EnrolleeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Enrollee",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46fa6c14-bcb8-473e-9f35-531677f8b437", null, "Enrollee", "ENROLLEE" },
                    { "cd5541e8-6e97-4dfb-9b9e-d69bd607c5f8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "15c9208b-1214-43b3-9ab8-95313c06e536", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "13d4c481-c0df-4f27-bd4f-6daad92ccbe1", new DateTime(2023, 3, 27, 16, 57, 17, 802, DateTimeKind.Local).AddTicks(307), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11d9d93f-71e0-40ee-9498-6315df8cce6a", false, "Caleb" },
                    { "20f80a55-351e-4be5-b7dd-ef1b9664ea87", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "4fcdb824-4c0c-4751-a7fb-bfb7c1e7a5f5", new DateTime(2023, 3, 27, 16, 57, 17, 802, DateTimeKind.Local).AddTicks(319), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9dfd64b0-6127-4c8c-b48a-8d3a81c04f69", false, "maraxhi" },
                    { "c5024f27-e6da-4f5d-a249-8ca162be4a80", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "80933bd9-448c-49b6-8c81-f34b76130828", new DateTime(2023, 3, 27, 16, 57, 17, 802, DateTimeKind.Local).AddTicks(268), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d2028435-5111-42eb-a211-0193e3c4ad8d", false, "SobTech" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollee_EnrolleeId",
                table: "Reports",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Enrollee_EnrolleeId",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46fa6c14-bcb8-473e-9f35-531677f8b437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd5541e8-6e97-4dfb-9b9e-d69bd607c5f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15c9208b-1214-43b3-9ab8-95313c06e536");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20f80a55-351e-4be5-b7dd-ef1b9664ea87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5024f27-e6da-4f5d-a249-8ca162be4a80");

            migrationBuilder.RenameColumn(
                name: "EnrolleeId",
                table: "Reports",
                newName: "Enrolleeid");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_EnrolleeId",
                table: "Reports",
                newName: "IX_Reports_Enrolleeid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enrollee",
                newName: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ea8e304-3811-4875-9de4-499ead801efe", null, "Admin", "ADMIN" },
                    { "5447774f-fd90-440c-87b6-cd1484ffd7d4", null, "Enrollee", "ENROLLEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14bd3734-1b1b-4a5b-9636-fa2c6a3c4fc3", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "64a95c94-32e4-4577-8c24-69ffadcb04b0", new DateTime(2023, 3, 27, 16, 47, 40, 221, DateTimeKind.Local).AddTicks(9357), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c998cd1f-79c2-4628-a99e-190da12d27c8", false, "maraxhi" },
                    { "cafd2387-625b-40e7-8b8b-a94f54c3cc89", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "5163be41-ac7d-4b2e-9f60-15583e79a09b", new DateTime(2023, 3, 27, 16, 47, 40, 221, DateTimeKind.Local).AddTicks(9308), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cbe5b5a2-12b2-472d-b730-6fa82e83d53d", false, "SobTech" },
                    { "e33b9058-c761-43ca-8ce9-9080a1706e20", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "d4962ec4-744f-4d82-a558-134560717d83", new DateTime(2023, 3, 27, 16, 47, 40, 221, DateTimeKind.Local).AddTicks(9339), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f0e6a48-902e-4ca5-95f1-3b0dd271c96d", false, "Caleb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollee_Enrolleeid",
                table: "Reports",
                column: "Enrolleeid",
                principalTable: "Enrollee",
                principalColumn: "id");
        }
    }
}
