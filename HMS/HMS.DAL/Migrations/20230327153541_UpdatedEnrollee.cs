using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEnrollee : Migration
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
                keyValue: "300c75f2-88d7-4a86-996d-189c46f8c5f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa67ff7-2c53-48c2-bf21-d97db66f7cd3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b53480f-f539-43c8-8e2d-e0cb539390a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de779f82-456e-462b-a225-2310746243a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e548b05d-e04a-4c7e-94d1-5b2beeb71f4c");

            migrationBuilder.AlterColumn<int>(
                name: "Enrolleeid",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26f07371-19b5-4cfb-9f92-aab06965fc42", null, "Enrollee", "ENROLLEE" },
                    { "4bb0068e-0e0d-4cb0-bc36-394189378092", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "43f38469-4214-4dd7-8b91-7ce4feb76022", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "547cbb56-5273-4b28-beff-e137c990e6bb", new DateTime(2023, 3, 27, 16, 35, 40, 552, DateTimeKind.Local).AddTicks(9995), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d90a4e9d-9ea9-41d8-97af-4334a8a14255", false, "maraxhi" },
                    { "76941694-bdea-4b88-b5b3-b698d9714899", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "fa424205-20e3-4780-ac5d-2b754d5afd1c", new DateTime(2023, 3, 27, 16, 35, 40, 552, DateTimeKind.Local).AddTicks(9949), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "54faa7d9-05fd-4bf4-91f9-7abb38fc9c13", false, "SobTech" },
                    { "d71e4283-40b6-4120-9f7e-cf5c63a936ed", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "e62aeaa2-636c-4762-a50f-38812f85a54b", new DateTime(2023, 3, 27, 16, 35, 40, 552, DateTimeKind.Local).AddTicks(9981), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4a567712-55eb-4715-b9d5-fab06ad4ae8b", false, "Caleb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollee_Enrolleeid",
                table: "Reports",
                column: "Enrolleeid",
                principalTable: "Enrollee",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Enrollee_Enrolleeid",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f07371-19b5-4cfb-9f92-aab06965fc42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb0068e-0e0d-4cb0-bc36-394189378092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43f38469-4214-4dd7-8b91-7ce4feb76022");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76941694-bdea-4b88-b5b3-b698d9714899");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d71e4283-40b6-4120-9f7e-cf5c63a936ed");

            migrationBuilder.AlterColumn<int>(
                name: "Enrolleeid",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "300c75f2-88d7-4a86-996d-189c46f8c5f5", null, "Admin", "ADMIN" },
                    { "7fa67ff7-2c53-48c2-bf21-d97db66f7cd3", null, "Enrollee", "ENROLLEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6b53480f-f539-43c8-8e2d-e0cb539390a1", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "08129a8a-c5da-4e7d-bba7-4211175f265a", new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9261), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "853d550c-ca40-4481-84d7-ba9bd10e5bcb", false, "SobTech" },
                    { "de779f82-456e-462b-a225-2310746243a7", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "831feb3a-5189-4b81-a0a6-42199bacb130", new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9322), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1ee773bf-d8df-4de7-b3b5-34406e0dbe4a", false, "maraxhi" },
                    { "e548b05d-e04a-4c7e-94d1-5b2beeb71f4c", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "f92bced5-88b6-435a-8f0d-7ef5f9bb6842", new DateTime(2023, 3, 27, 15, 44, 21, 54, DateTimeKind.Local).AddTicks(9311), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c03fc242-cabd-4f0b-a51f-ac6a227ffa53", false, "Caleb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollee_Enrolleeid",
                table: "Reports",
                column: "Enrolleeid",
                principalTable: "Enrollee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
