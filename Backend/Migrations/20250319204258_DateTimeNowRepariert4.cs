using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeNowRepariert4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833ee2b2-d6c7-4ecf-8362-a5f2eca8772a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89a91139-58de-4cf1-ae18-0ba5f848f823");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b0a4842-fd8b-4564-a768-14da2a71062a", null, "User", "USER" },
                    { "8fa7de5d-e4bc-4abd-9570-96977385b51c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0a4842-fd8b-4564-a768-14da2a71062a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa7de5d-e4bc-4abd-9570-96977385b51c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833ee2b2-d6c7-4ecf-8362-a5f2eca8772a", null, "Admin", "ADMIN" },
                    { "89a91139-58de-4cf1-ae18-0ba5f848f823", null, "User", "USER" }
                });
        }
    }
}
