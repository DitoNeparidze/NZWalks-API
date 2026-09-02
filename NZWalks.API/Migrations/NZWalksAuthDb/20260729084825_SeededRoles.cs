using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class SeededRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a39c5464-0f25-440c-b85f-2d48d1e1bcab", "a39c5464-0f25-440c-b85f-2d48d1e1bcab", "Reader", "READER" },
                    { "e9ebe8e0-242f-42d7-8459-80fddcdf40c4", "e9ebe8e0-242f-42d7-8459-80fddcdf40c4", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a39c5464-0f25-440c-b85f-2d48d1e1bcab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ebe8e0-242f-42d7-8459-80fddcdf40c4");
        }
    }
}
