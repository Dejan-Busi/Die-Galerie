using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class kommentarModelUmbenannt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bewertungen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6be1da91-4f72-46a2-be2e-d00e96073e5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83c2a4f-2ef2-48f3-95a4-bc8eecfb72a0");

            migrationBuilder.CreateTable(
                name: "Kommentare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Inhalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GepostetVon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GepostetAm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemaeldeId = table.Column<int>(type: "int", nullable: true)
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
                    { "1c2e8ff1-2e1e-48ef-84a7-ace3e598d193", null, "Admin", "ADMIN" },
                    { "97dda81a-462f-4022-81e7-36b19106479b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_GemaeldeId",
                table: "Kommentare",
                column: "GemaeldeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommentare");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c2e8ff1-2e1e-48ef-84a7-ace3e598d193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97dda81a-462f-4022-81e7-36b19106479b");

            migrationBuilder.CreateTable(
                name: "Bewertungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GemaeldeId = table.Column<int>(type: "int", nullable: true),
                    GepostetAm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GepostetVon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewertungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bewertungen_Gemaelder_GemaeldeId",
                        column: x => x.GemaeldeId,
                        principalTable: "Gemaelder",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6be1da91-4f72-46a2-be2e-d00e96073e5e", null, "Admin", "ADMIN" },
                    { "e83c2a4f-2ef2-48f3-95a4-bc8eecfb72a0", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bewertungen_GemaeldeId",
                table: "Bewertungen",
                column: "GemaeldeId");
        }
    }
}
