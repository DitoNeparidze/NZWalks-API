using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("543b461f-ccb5-4b6c-a4b6-f4613cbe45fe"), "Easy" },
                    { new Guid("a2ac30a3-b0af-4bfc-8b7b-10500d090aa8"), "Hard" },
                    { new Guid("b8f1bfe5-d42e-4383-95f6-97aedb16eae5"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1c748ec2-980e-4f96-b644-e7fbf64ce600"), "STL", "Southland", "https://images.pexels.com/photos/34549718/pexels-photo-34549718.jpeg" },
                    { new Guid("1dd49446-5834-4e1c-9dbf-ad1c2a7c9d7b"), "BOP", "Bay Of Plenty", "https://images.pexels.com/photos/32947345/pexels-photo-32947345.jpeg" },
                    { new Guid("9327e0b5-314f-43b1-bfcc-e95b1775c965"), "WGN", "Wellington", "https://images.pexels.com/photos/10097260/pexels-photo-10097260.jpeg" },
                    { new Guid("9ac3a0f6-6ff7-4b76-adde-c948fb0b7015"), "AKL", "Auckland", "https://images.pexels.com/photos/17824133/pexels-photo-17824133.jpeg" },
                    { new Guid("a945243c-27eb-47d1-b6d6-aadc97d83dc2"), "NSN", "Nelson", "https://images.pexels.com/photos/3396855/pexels-photo-3396855.jpeg" },
                    { new Guid("f35a94fe-b583-42fd-868b-dc53496adc5a"), "NTL", "Northland", "https://images.pexels.com/photos/32947330/pexels-photo-32947330.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("543b461f-ccb5-4b6c-a4b6-f4613cbe45fe"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a2ac30a3-b0af-4bfc-8b7b-10500d090aa8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b8f1bfe5-d42e-4383-95f6-97aedb16eae5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1c748ec2-980e-4f96-b644-e7fbf64ce600"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1dd49446-5834-4e1c-9dbf-ad1c2a7c9d7b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9327e0b5-314f-43b1-bfcc-e95b1775c965"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9ac3a0f6-6ff7-4b76-adde-c948fb0b7015"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a945243c-27eb-47d1-b6d6-aadc97d83dc2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f35a94fe-b583-42fd-868b-dc53496adc5a"));
        }
    }
}
