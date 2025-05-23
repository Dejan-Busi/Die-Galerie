using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGepostetVonNeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9181629-9645-448f-aeff-66f6bed7dab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc67a860-876d-4666-928e-cafa2b84ab4b");

            migrationBuilder.DropColumn(
                name: "BewertungId",
                table: "Gemaelder");

            migrationBuilder.DropColumn(
                name: "KommentarId",
                table: "Gemaelder");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a72b3b38-977f-4dde-bfaa-173fc1f868b4", null, "User", "USER" },
                    { "b475d385-0e27-4064-8991-62c645ce9f5b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a72b3b38-977f-4dde-bfaa-173fc1f868b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b475d385-0e27-4064-8991-62c645ce9f5b");

            migrationBuilder.AddColumn<int>(
                name: "BewertungId",
                table: "Gemaelder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KommentarId",
                table: "Gemaelder",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9181629-9645-448f-aeff-66f6bed7dab1", null, "Admin", "ADMIN" },
                    { "cc67a860-876d-4666-928e-cafa2b84ab4b", null, "User", "USER" }
                });
        }
    }
}
