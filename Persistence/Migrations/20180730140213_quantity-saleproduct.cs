using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class quantitysaleproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Sales",
                newName: "TotalSalePrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SaleProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalProductPrice",
                table: "SaleProduct",
                nullable: false,
                defaultValue: 0m);

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
                columns: new[] { "LastModified", "Quantity", "TotalProductPrice" },
                values: new object[] { new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local), 1, 3m });

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "SaleId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "LastModified", "Quantity", "TotalProductPrice" },
                values: new object[] { new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local), 2, 4m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "TotalSalePrice" },
                values: new object[] { new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SaleProduct");

            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "SaleProduct");

            migrationBuilder.RenameColumn(
                name: "TotalSalePrice",
                table: "Sales",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "Price");

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
                values: new object[] { new DateTime(2018, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), 3m });
        }
    }
}
