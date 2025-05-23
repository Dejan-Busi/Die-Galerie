using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class rememberMe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c2e8ff1-2e1e-48ef-84a7-ace3e598d193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97dda81a-462f-4022-81e7-36b19106479b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bcadb09-2f40-4363-91f6-803b8c87b89f", null, "Admin", "ADMIN" },
                    { "33178f96-b1f5-4f10-bfad-d77e2a409947", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bcadb09-2f40-4363-91f6-803b8c87b89f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33178f96-b1f5-4f10-bfad-d77e2a409947");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c2e8ff1-2e1e-48ef-84a7-ace3e598d193", null, "Admin", "ADMIN" },
                    { "97dda81a-462f-4022-81e7-36b19106479b", null, "User", "USER" }
                });
        }
    }
}
