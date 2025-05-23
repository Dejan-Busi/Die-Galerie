using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RememberMEInLoginResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "9fe86067-961f-458b-978b-3be34f614b69", null, "Admin", "ADMIN" },
                    { "b7772284-3e1e-4448-bac1-6132dff4f846", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe86067-961f-458b-978b-3be34f614b69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7772284-3e1e-4448-bac1-6132dff4f846");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dbc7e44-4bb9-442b-ac85-fbea21b41443", null, "User", "USER" },
                    { "461f2b8c-6e3d-46a5-bc0e-481c3bdd3030", null, "Admin", "ADMIN" }
                });
        }
    }
}
