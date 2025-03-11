using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class GemaeldeAlterEntfernt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1bf116b-0f31-4d7f-8c41-bf96fa76e161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44d7e4c-1101-4fe6-9b51-98fc9baddf37");

            migrationBuilder.DropColumn(
                name: "Alter",
                table: "Gemaelder");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c93728d-8512-4806-9479-a48948146573", null, "User", "USER" },
                    { "b7873e01-7ed5-4e32-9a54-9ce1d51b0971", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c93728d-8512-4806-9479-a48948146573");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7873e01-7ed5-4e32-9a54-9ce1d51b0971");

            migrationBuilder.AddColumn<string>(
                name: "Alter",
                table: "Gemaelder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e1bf116b-0f31-4d7f-8c41-bf96fa76e161", null, "User", "USER" },
                    { "e44d7e4c-1101-4fe6-9b51-98fc9baddf37", null, "Admin", "ADMIN" }
                });
        }
    }
}
