using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Bewertung_Neue_Attribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommentare");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d058442-c69b-474e-8bcf-ef96051be796");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd248704-b63e-43c9-b049-9e43810a993d");

            migrationBuilder.AddColumn<DateTime>(
                name: "GepostetAm",
                table: "Bewertungen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GepostetVon",
                table: "Bewertungen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kommentar",
                table: "Bewertungen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eabc72b-8626-4ffd-8328-73f4e6f8363c", null, "User", "USER" },
                    { "3e414b20-0b67-4b98-8e6e-d9f4c26f7c96", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eabc72b-8626-4ffd-8328-73f4e6f8363c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e414b20-0b67-4b98-8e6e-d9f4c26f7c96");

            migrationBuilder.DropColumn(
                name: "GepostetAm",
                table: "Bewertungen");

            migrationBuilder.DropColumn(
                name: "GepostetVon",
                table: "Bewertungen");

            migrationBuilder.DropColumn(
                name: "Kommentar",
                table: "Bewertungen");

            migrationBuilder.CreateTable(
                name: "Kommentare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GemaeldeId = table.Column<int>(type: "int", nullable: true),
                    GepostetAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GepostetVon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inhalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kommentare_Gemaelder_GemaeldeId",
                        column: x => x.GemaeldeId,
                        principalTable: "Gemaelder",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d058442-c69b-474e-8bcf-ef96051be796", null, "User", "USER" },
                    { "cd248704-b63e-43c9-b049-9e43810a993d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_GemaeldeId",
                table: "Kommentare",
                column: "GemaeldeId");
        }
    }
}
