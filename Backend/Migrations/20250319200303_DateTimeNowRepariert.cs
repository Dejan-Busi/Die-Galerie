using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNowRepariert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8418749b-549e-48cd-b995-29a9ee4e2c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d530bc76-2a12-4a82-ae8f-6a4b58458853");

            migrationBuilder.AlterColumn<string>(
                name: "GepostetAm",
                table: "Bewertungen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17081961-dc8c-4f0a-899d-442c6cb34969", null, "Admin", "ADMIN" },
                    { "547932c9-0cc3-4a4f-a1b3-e4f280540428", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17081961-dc8c-4f0a-899d-442c6cb34969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "547932c9-0cc3-4a4f-a1b3-e4f280540428");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GepostetAm",
                table: "Bewertungen",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8418749b-549e-48cd-b995-29a9ee4e2c0d", null, "User", "USER" },
                    { "d530bc76-2a12-4a82-ae8f-6a4b58458853", null, "Admin", "ADMIN" }
                });
        }
    }
}
