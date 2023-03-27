using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createdEnrolleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Appointments_AppointmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Plans_PlanId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlanId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468939a-7269-482a-91e2-23837cc87ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78fda444-61de-480f-86f8-7868ce38bd12");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AspNetUsers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AspNetUsers",
                newName: "EnrolleeId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AppointmentId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_EnrolleeId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnrolleId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enrollee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enrollee_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollee_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9dfe79a4-80ac-4e12-8992-64c0c95a86c3", null, "Admin", "ADMIN" },
                    { "b27010e7-dc98-4249-8c1d-cd8979d43d69", null, "Enrollee", "ENROLLEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EnrolleeId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProviderId", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "01024324-99ec-47c2-92a4-9ea8a53b7762", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "487b3d17-36be-445c-9cfa-af1a20cb0f49", new DateTime(2023, 3, 27, 0, 19, 12, 855, DateTimeKind.Local).AddTicks(6824), "bellos@gmail.com", false, null, "Bello", 0, "Soliu", false, null, null, null, null, "@Bello123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29efe4d5-8da6-45e5-a437-e93cec4fa4bb", false, "SobTech" },
                    { "25461733-462e-4332-93bb-e8ad29ffc555", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "f6b7f7e6-8e66-4033-9d72-7831df021417", new DateTime(2023, 3, 27, 0, 19, 12, 855, DateTimeKind.Local).AddTicks(6837), "caleb@gmail.com", false, null, "Caleb", 0, "Okechi", false, null, null, null, null, "@Caleb123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "63fc6f43-4de1-429a-90fb-b828f4f2cb69", false, "Caleb" },
                    { "3107b321-ac51-49ee-b767-2c568e728908", 0, "583 Wall Dr. Gwynn Oak, MD 21207", "f3ac7496-fed9-4c32-8647-c0ca5eb3bc47", new DateTime(2023, 3, 27, 0, 19, 12, 855, DateTimeKind.Local).AddTicks(6850), "amara@gmail.com", false, null, "Amarachi", 1, "Izuegbu", false, null, null, null, null, "@Amara123", "07038730732", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "af1075c8-0e94-48d5-875a-422fc3516e02", false, "maraxhi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProviderId",
                table: "AspNetUsers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProviderId",
                table: "Appointments",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollee_AppointmentId",
                table: "Enrollee",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollee_PlanId",
                table: "Enrollee",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Provider_ProviderId",
                table: "Appointments",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enrollee_EnrolleeId",
                table: "AspNetUsers",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Provider_ProviderId",
                table: "AspNetUsers",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Provider_ProviderId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enrollee_EnrolleeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Provider_ProviderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrollee");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProviderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProviderId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dfe79a4-80ac-4e12-8992-64c0c95a86c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b27010e7-dc98-4249-8c1d-cd8979d43d69");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01024324-99ec-47c2-92a4-9ea8a53b7762");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25461733-462e-4332-93bb-e8ad29ffc555");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3107b321-ac51-49ee-b767-2c568e728908");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnrolleId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "AspNetUsers",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "EnrolleeId",
                table: "AspNetUsers",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_EnrolleeId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AppointmentId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0468939a-7269-482a-91e2-23837cc87ee7", null, "Admin", "Admin" },
                    { "78fda444-61de-480f-86f8-7868ce38bd12", null, "Enrolle", "Enrolle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlanId",
                table: "AspNetUsers",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Appointments_AppointmentId",
                table: "AspNetUsers",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plans_PlanId",
                table: "AspNetUsers",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");
        }
    }
}
