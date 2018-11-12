using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updatesaleproductproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProductPrice",
                table: "SaleProduct",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 8, 3, 17, 36, 43, 939, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2018, 8, 3, 17, 36, 43, 955, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2018, 8, 3, 17, 36, 43, 955, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 8, 2, 17, 36, 43, 955, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "LastModified",
                value: new DateTime(2018, 8, 3, 17, 36, 43, 955, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "LastModified",
                value: new DateTime(2018, 8, 3, 17, 36, 43, 955, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "TotalSalePrice" },
                values: new object[] { new DateTime(2018, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProductPrice",
                table: "SaleProduct",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 30, 9, 2, 12, 769, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2018, 7, 30, 9, 2, 12, 771, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2018, 7, 30, 9, 2, 12, 776, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 29, 9, 2, 12, 776, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "LastModified",
                value: new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "LastModified",
                value: new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "TotalSalePrice" },
                values: new object[] { new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), 7m });
        }
    }
}
