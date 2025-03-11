using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NoteAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eabc72b-8626-4ffd-8328-73f4e6f8363c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e414b20-0b67-4b98-8e6e-d9f4c26f7c96");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Bewertungen",
                newName: "Note");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57595473-f20b-461b-a78f-bf1ff909e68e", null, "User", "USER" },
                    { "5b32668d-cb9c-4074-9e51-1069f56b2e7b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57595473-f20b-461b-a78f-bf1ff909e68e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b32668d-cb9c-4074-9e51-1069f56b2e7b");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Bewertungen",
                newName: "Rating");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eabc72b-8626-4ffd-8328-73f4e6f8363c", null, "User", "USER" },
                    { "3e414b20-0b67-4b98-8e6e-d9f4c26f7c96", null, "Admin", "ADMIN" }
                });
        }
    }
}
