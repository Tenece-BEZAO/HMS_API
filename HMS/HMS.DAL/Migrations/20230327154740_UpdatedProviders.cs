using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollee_Appointments_AppointmentId",
                table: "Enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AppUserId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AppUserId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Enrollee_AppointmentId",
                table: "Enrollee");

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

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Enrollee");

            migrationBuilder.RenameColumn(
                name: "EnrolleId",
                table: "Appointments",
                newName: "EnrolleeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EnrolleeId",
                table: "Appointments",
                column: "EnrolleeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Enrollee_EnrolleeId",
                table: "Appointments",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Enrollee_EnrolleeId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_EnrolleeId",
                table: "Appointments");

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
                name: "EnrolleeId",
                table: "Appointments",
                newName: "EnrolleId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Enrollee",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AppUserId1",
                table: "Reports",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollee_AppointmentId",
                table: "Enrollee",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollee_Appointments_AppointmentId",
                table: "Enrollee",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AppUserId1",
                table: "Reports",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
