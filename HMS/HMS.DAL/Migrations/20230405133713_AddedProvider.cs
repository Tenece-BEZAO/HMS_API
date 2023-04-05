using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class AddedProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredDate",
                table: "Provider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44e0fcdb-9fc6-49e5-9b72-6522ffa439e0", "f86f66cd-9bf3-4e0f-9d72-ebe578329636", "Enrollee", "ENROLLEE" },
                    { "7120e2b5-de12-4ff7-ad75-ea7222c94a91", "fbb23154-fe09-4a52-b05d-4d8a5e479a85", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0be87530-3828-48d2-8681-eb5699055936", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "3cacf6a4-091b-40fb-9819-daff4a483c0a", new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2706), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1ad1a83a-260b-4531-ade1-40be40fa90e0", false, "Caleb" },
                    { "40987c42-b29d-4eff-a3dc-2fe5d7389b64", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "491cf6b2-ecaa-472f-8ecd-9402ce5d639a", new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2684), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51ccddfd-3e51-459c-a2d6-c99c7ae4b0f7", false, "SobTech" },
                    { "dab77144-35fa-4fe8-a676-e4deeeccbdc1", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "baaefa5c-0de1-4484-ba83-6d81eb997d3c", new DateTime(2023, 4, 5, 14, 37, 13, 112, DateTimeKind.Local).AddTicks(2715), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43d05bee-ca4c-4939-9526-57d5d2187b3d", false, "maraxhi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e0fcdb-9fc6-49e5-9b72-6522ffa439e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7120e2b5-de12-4ff7-ad75-ea7222c94a91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0be87530-3828-48d2-8681-eb5699055936");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40987c42-b29d-4eff-a3dc-2fe5d7389b64");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dab77144-35fa-4fe8-a676-e4deeeccbdc1");

            migrationBuilder.DropColumn(
                name: "RegisteredDate",
                table: "Provider");

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
        }
    }
}
