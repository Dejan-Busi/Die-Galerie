using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class GemaeldeAlter : Migration
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
                keyValue: "1af91bdb-c20d-491b-9497-e60cb8f84558");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb6ae6b-1603-4380-9b13-52eb95224fe2");

            migrationBuilder.AddColumn<string>(
                name: "Alter",
                table: "Gemaelder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e1bf116b-0f31-4d7f-8c41-bf96fa76e161", null, "User", "USER" },
                    { "e44d7e4c-1101-4fe6-9b51-98fc9baddf37", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Kommentare_Gemaelder_GemaeldeId",
                table: "Kommentare",
                column: "GemaeldeId",
                principalTable: "Gemaelder",
                principalColumn: "Id");
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
                keyValue: "e1bf116b-0f31-4d7f-8c41-bf96fa76e161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44d7e4c-1101-4fe6-9b51-98fc9baddf37");

            migrationBuilder.DropColumn(
                name: "Alter",
                table: "Gemaelder");

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
    }
}
