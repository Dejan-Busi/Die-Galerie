using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGepostetVonNeuNeuNeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kommentare_Gemaelder_GemaeldeId",
                table: "Kommentare");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3731d667-ca19-49bd-a6b9-da5d16a48781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5aca01a-c268-4bb6-b6d8-996e544e3718");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1af91bdb-c20d-491b-9497-e60cb8f84558", null, "Admin", "ADMIN" },
                    { "fcb6ae6b-1603-4380-9b13-52eb95224fe2", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Kommentare_Gemaelder_GemaeldeId",
                table: "Kommentare",
                column: "GemaeldeId",
                principalTable: "Gemaelder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kommentare_Gemaelder_GemaeldeId",
                table: "Kommentare");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1af91bdb-c20d-491b-9497-e60cb8f84558");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb6ae6b-1603-4380-9b13-52eb95224fe2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3731d667-ca19-49bd-a6b9-da5d16a48781", null, "User", "USER" },
                    { "a5aca01a-c268-4bb6-b6d8-996e544e3718", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Kommentare_Gemaelder_GemaeldeId",
                table: "Kommentare",
                column: "GemaeldeId",
                principalTable: "Gemaelder",
                principalColumn: "Id");
        }
    }
}
