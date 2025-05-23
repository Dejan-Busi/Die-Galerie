using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class rememberMeAttributee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0a3197c-1e59-423d-adc2-3c562e1466ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff12faa4-fa49-43fb-8b7d-39d43412bbf7");

            migrationBuilder.AddColumn<bool>(
                name: "RememberMe",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14e05305-074c-4501-b5cb-7d1bfc608934", null, "User", "USER" },
                    { "6ce4c46e-6229-4314-aa18-db8eefd4be44", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14e05305-074c-4501-b5cb-7d1bfc608934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ce4c46e-6229-4314-aa18-db8eefd4be44");

            migrationBuilder.DropColumn(
                name: "RememberMe",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0a3197c-1e59-423d-adc2-3c562e1466ca", null, "User", "USER" },
                    { "ff12faa4-fa49-43fb-8b7d-39d43412bbf7", null, "Admin", "ADMIN" }
                });
        }
    }
}
