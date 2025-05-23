using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateEndpoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee3d2cb6-db4b-46e9-82e6-84c007828895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffd4d95d-dddd-43cb-a19d-7779a7b57612");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6be1da91-4f72-46a2-be2e-d00e96073e5e", null, "Admin", "ADMIN" },
                    { "e83c2a4f-2ef2-48f3-95a4-bc8eecfb72a0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6be1da91-4f72-46a2-be2e-d00e96073e5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83c2a4f-2ef2-48f3-95a4-bc8eecfb72a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee3d2cb6-db4b-46e9-82e6-84c007828895", null, "User", "USER" },
                    { "ffd4d95d-dddd-43cb-a19d-7779a7b57612", null, "Admin", "ADMIN" }
                });
        }
    }
}
