using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class rememberMeAttributeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c1f14b-50b1-4161-92da-06b37c1b7d48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e71bfbbd-3ada-4a3b-b05d-a4f0c94eed58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9acb94fc-a989-4ee4-a397-ed68b8d7bc58", null, "User", "USER" },
                    { "eff7b4fa-ce21-4597-be97-fb97d80b5307", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9acb94fc-a989-4ee4-a397-ed68b8d7bc58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff7b4fa-ce21-4597-be97-fb97d80b5307");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e3c1f14b-50b1-4161-92da-06b37c1b7d48", null, "User", "USER" },
                    { "e71bfbbd-3ada-4a3b-b05d-a4f0c94eed58", null, "Admin", "ADMIN" }
                });
        }
    }
}
