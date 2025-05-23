using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNowRepariert5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0a4842-fd8b-4564-a768-14da2a71062a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa7de5d-e4bc-4abd-9570-96977385b51c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e26652e-c23a-4d33-81ff-9b77213d3ff0", null, "User", "USER" },
                    { "cc9afc67-b805-4b00-b49a-3e703f9d3080", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e26652e-c23a-4d33-81ff-9b77213d3ff0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9afc67-b805-4b00-b49a-3e703f9d3080");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b0a4842-fd8b-4564-a768-14da2a71062a", null, "User", "USER" },
                    { "8fa7de5d-e4bc-4abd-9570-96977385b51c", null, "Admin", "ADMIN" }
                });
        }
    }
}
