using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PJATK_APBD_Cw7_s33463.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacture",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 2, "NV", new DateOnly(1993, 4, 5), "NVIDIA Corporation" },
                    { 3, "COR", new DateOnly(1994, 1, 1), "Corsair Gaming Inc." }
                });

            migrationBuilder.InsertData(
                table: "ComponentType",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Processor" },
                    { 2, "GPU", "Graphics Card" },
                    { 3, "RAM", "Memory" }
                });

            migrationBuilder.InsertData(
                table: "PC",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5f },
                    { 2, new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.2f }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU0000001", 1, 1, "8-core gaming processor", "Ryzen 7 7800X3D" },
                    { "GPU0000001", 2, 2, "High-end gaming graphics card", "RTX 4080 Super" },
                    { "RAM0000001", 3, 3, "DDR5 RAM module 16GB", "Corsair Vengeance DDR5 16GB" }
                });

            migrationBuilder.InsertData(
                table: "PCComponent",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "CPU0000001", 1, 1 },
                    { "GPU0000001", 1, 1 },
                    { "RAM0000001", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "CPU0000001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "GPU0000001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "RAM0000001", 1 });

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "CPU0000001");

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "GPU0000001");

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "RAM0000001");

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacture",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacture",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacture",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
