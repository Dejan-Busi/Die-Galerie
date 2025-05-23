using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNowRepariert2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17081961-dc8c-4f0a-899d-442c6cb34969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "547932c9-0cc3-4a4f-a1b3-e4f280540428");

            migrationBuilder.DropColumn(
                name: "GepostetAm",
                table: "Bewertungen");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Datum",
                table: "Bewertungen",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Uhrzeit",
                table: "Bewertungen",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9dcb4230-d60b-4d8b-a145-cc7884d8bd36", null, "Admin", "ADMIN" },
                    { "bb9dd29f-d3cc-4936-a0c3-651e4ac3d427", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dcb4230-d60b-4d8b-a145-cc7884d8bd36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb9dd29f-d3cc-4936-a0c3-651e4ac3d427");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Bewertungen");

            migrationBuilder.DropColumn(
                name: "Uhrzeit",
                table: "Bewertungen");

            migrationBuilder.AddColumn<string>(
                name: "GepostetAm",
                table: "Bewertungen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17081961-dc8c-4f0a-899d-442c6cb34969", null, "Admin", "ADMIN" },
                    { "547932c9-0cc3-4a4f-a1b3-e4f280540428", null, "User", "USER" }
                });
        }
    }
}
