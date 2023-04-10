using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEnrolleeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Enrollee_EnrolleeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enrollee_EnrolleeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollee_Plans_PlanId",
                table: "Enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Enrollee_EnrolleeId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollee",
                table: "Enrollee");

            migrationBuilder.DropIndex(
                name: "IX_Enrollee_PlanId",
                table: "Enrollee");

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

            migrationBuilder.RenameTable(
                name: "Enrollee",
                newName: "Enrollees");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Enrollees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollees",
                table: "Enrollees",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees",
                column: "PlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Enrollees_EnrolleeId",
                table: "Appointments",
                column: "EnrolleeId",
                principalTable: "Enrollees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enrollees_EnrolleeId",
                table: "AspNetUsers",
                column: "EnrolleeId",
                principalTable: "Enrollees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollees_EnrolleeId",
                table: "Reports",
                column: "EnrolleeId",
                principalTable: "Enrollees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Enrollees_EnrolleeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enrollees_EnrolleeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollees_Plans_PlanId",
                table: "Enrollees");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Enrollees_EnrolleeId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollees",
                table: "Enrollees");

            migrationBuilder.DropIndex(
                name: "IX_Enrollees_PlanId",
                table: "Enrollees");

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

            migrationBuilder.RenameTable(
                name: "Enrollees",
                newName: "Enrollee");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Enrollee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollee",
                table: "Enrollee",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollee_PlanId",
                table: "Enrollee",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Enrollee_EnrolleeId",
                table: "Appointments",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enrollee_EnrolleeId",
                table: "AspNetUsers",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollee_Plans_PlanId",
                table: "Enrollee",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Enrollee_EnrolleeId",
                table: "Reports",
                column: "EnrolleeId",
                principalTable: "Enrollee",
                principalColumn: "Id");
        }
    }
}
