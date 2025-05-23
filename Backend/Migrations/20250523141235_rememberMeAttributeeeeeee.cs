using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class rememberMeAttributeeeeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9acb94fc-a989-4ee4-a397-ed68b8d7bc58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff7b4fa-ce21-4597-be97-fb97d80b5307");

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
                    { "2920eba6-a664-4b19-9400-5f407549fdd7", null, "User", "USER" },
                    { "77153701-241a-46c7-8390-bd2728985b3a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2920eba6-a664-4b19-9400-5f407549fdd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77153701-241a-46c7-8390-bd2728985b3a");

            migrationBuilder.DropColumn(
                name: "RememberMe",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9acb94fc-a989-4ee4-a397-ed68b8d7bc58", null, "User", "USER" },
                    { "eff7b4fa-ce21-4597-be97-fb97d80b5307", null, "Admin", "ADMIN" }
                });
        }
    }
}
