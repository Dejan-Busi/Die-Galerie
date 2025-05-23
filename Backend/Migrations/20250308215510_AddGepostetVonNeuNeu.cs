using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGepostetVonNeuNeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a72b3b38-977f-4dde-bfaa-173fc1f868b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b475d385-0e27-4064-8991-62c645ce9f5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3731d667-ca19-49bd-a6b9-da5d16a48781", null, "User", "USER" },
                    { "a5aca01a-c268-4bb6-b6d8-996e544e3718", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3731d667-ca19-49bd-a6b9-da5d16a48781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5aca01a-c268-4bb6-b6d8-996e544e3718");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a72b3b38-977f-4dde-bfaa-173fc1f868b4", null, "User", "USER" },
                    { "b475d385-0e27-4064-8991-62c645ce9f5b", null, "Admin", "ADMIN" }
                });
        }
    }
}
