using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedEnrolleeFKConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees");

            migrationBuilder.DropIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75ddc14c-ebd6-460b-a870-73dececb02b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee26646-93a9-446a-8c9f-6df2605766c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52c60c5b-87dd-44a9-b52a-c6f918bab136");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5adc840c-dd3a-411a-9a1a-34708caa6ced");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6cf917a9-fc6b-4f77-bc0a-378fc4717c10");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Enrollees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees");

            migrationBuilder.DropIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees");

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

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Enrollees",
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
                    { "75ddc14c-ebd6-460b-a870-73dececb02b5", null, "Enrollee", "ENROLLEE" },
                    { "eee26646-93a9-446a-8c9f-6df2605766c9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "52c60c5b-87dd-44a9-b52a-c6f918bab136", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "18d1b305-e88f-4369-a6ce-db1345e14e8f", new DateTime(2023, 4, 11, 19, 1, 17, 642, DateTimeKind.Local).AddTicks(510), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b1ea89d6-b6ea-4a14-b963-5fcff3f298a3", false, "Caleb" },
                    { "5adc840c-dd3a-411a-9a1a-34708caa6ced", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "5df63e35-f0c7-4033-808a-318ef4968fd3", new DateTime(2023, 4, 11, 19, 1, 17, 642, DateTimeKind.Local).AddTicks(526), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bf0beb13-b838-4247-8fe1-025371e25714", false, "maraxhi" },
                    { "6cf917a9-fc6b-4f77-bc0a-378fc4717c10", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "2b039799-b898-4bef-b3e6-a2cd5979537c", new DateTime(2023, 4, 11, 19, 1, 17, 642, DateTimeKind.Local).AddTicks(474), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7392712d-5018-4a16-bc21-1a42857ada16", false, "SobTech" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees",
                column: "PlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
