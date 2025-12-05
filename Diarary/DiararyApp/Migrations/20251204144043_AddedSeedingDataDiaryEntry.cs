using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiararyApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Create", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with Joe!", new DateTime(2025, 12, 4, 15, 40, 43, 66, DateTimeKind.Local).AddTicks(9220), "Went Hiking" },
                    { 2, "Went Shopping with Joe!", new DateTime(2025, 12, 4, 15, 40, 43, 66, DateTimeKind.Local).AddTicks(9420), "Went Shopping" },
                    { 3, "Went Diving with Joe!", new DateTime(2025, 12, 4, 15, 40, 43, 66, DateTimeKind.Local).AddTicks(9423), "Went Diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
