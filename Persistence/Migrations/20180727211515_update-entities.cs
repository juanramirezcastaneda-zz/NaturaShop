using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updateentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 27, 16, 15, 14, 374, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2018, 7, 27, 16, 15, 14, 377, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "Quantity", "TotalPrice" },
                values: new object[] { new DateTime(2018, 7, 27, 16, 15, 14, 380, DateTimeKind.Local), 1, 3m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "Quantity", "TotalPrice" },
                values: new object[] { new DateTime(2018, 7, 26, 16, 15, 14, 380, DateTimeKind.Local), 2, 4m });

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "LastModified",
                value: new DateTime(2018, 7, 27, 16, 15, 14, 389, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "LastModified",
                value: new DateTime(2018, 7, 27, 16, 15, 14, 389, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "TotalPrice" },
                values: new object[] { new DateTime(2018, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 26, 8, 17, 26, 235, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2018, 7, 26, 8, 17, 26, 237, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2018, 7, 26, 8, 17, 26, 240, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 25, 8, 17, 26, 240, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "LastModified",
                value: new DateTime(2018, 7, 26, 8, 17, 26, 248, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "LastModified",
                value: new DateTime(2018, 7, 26, 8, 17, 26, 248, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "Quantity", "TotalPrice" },
                values: new object[] { new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, 3m });
        }
    }
}
