using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNowRepariert3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "833ee2b2-d6c7-4ecf-8362-a5f2eca8772a", null, "Admin", "ADMIN" },
                    { "89a91139-58de-4cf1-ae18-0ba5f848f823", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833ee2b2-d6c7-4ecf-8362-a5f2eca8772a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89a91139-58de-4cf1-ae18-0ba5f848f823");

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
    }
}
