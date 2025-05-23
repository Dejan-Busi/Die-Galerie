using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e26652e-c23a-4d33-81ff-9b77213d3ff0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9afc67-b805-4b00-b49a-3e703f9d3080");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b29add60-bf1e-44d1-87a2-b27481492cf6", null, "Admin", "ADMIN" },
                    { "ba146761-baf2-490d-b6df-4325345373c0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Gemaelder",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mona Lisa" },
                    { 2, "Scream" },
                    { 3, "Letztes Abendmal" },
                    { 4, "Sternennacht" },
                    { 5, "Creation of Adam" },
                    { 6, "The Kiss" },
                    { 7, "The Girl" },
                    { 8, "Venus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b29add60-bf1e-44d1-87a2-b27481492cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba146761-baf2-490d-b6df-4325345373c0");

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gemaelder",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e26652e-c23a-4d33-81ff-9b77213d3ff0", null, "User", "USER" },
                    { "cc9afc67-b805-4b00-b49a-3e703f9d3080", null, "Admin", "ADMIN" }
                });
        }
    }
}
