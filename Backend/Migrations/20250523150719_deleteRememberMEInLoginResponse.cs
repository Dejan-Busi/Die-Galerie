using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class deleteRememberMEInLoginResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2920eba6-a664-4b19-9400-5f407549fdd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77153701-241a-46c7-8390-bd2728985b3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dbc7e44-4bb9-442b-ac85-fbea21b41443", null, "User", "USER" },
                    { "461f2b8c-6e3d-46a5-bc0e-481c3bdd3030", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dbc7e44-4bb9-442b-ac85-fbea21b41443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "461f2b8c-6e3d-46a5-bc0e-481c3bdd3030");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2920eba6-a664-4b19-9400-5f407549fdd7", null, "User", "USER" },
                    { "77153701-241a-46c7-8390-bd2728985b3a", null, "Admin", "ADMIN" }
                });
        }
    }
}
