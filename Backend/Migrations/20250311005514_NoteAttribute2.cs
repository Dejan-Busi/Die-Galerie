using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NoteAttribute2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57595473-f20b-461b-a78f-bf1ff909e68e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b32668d-cb9c-4074-9e51-1069f56b2e7b");

            migrationBuilder.AlterColumn<int>(
                name: "Note",
                table: "Bewertungen",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8418749b-549e-48cd-b995-29a9ee4e2c0d", null, "User", "USER" },
                    { "d530bc76-2a12-4a82-ae8f-6a4b58458853", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8418749b-549e-48cd-b995-29a9ee4e2c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d530bc76-2a12-4a82-ae8f-6a4b58458853");

            migrationBuilder.AlterColumn<float>(
                name: "Note",
                table: "Bewertungen",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57595473-f20b-461b-a78f-bf1ff909e68e", null, "User", "USER" },
                    { "5b32668d-cb9c-4074-9e51-1069f56b2e7b", null, "Admin", "ADMIN" }
                });
        }
    }
}
