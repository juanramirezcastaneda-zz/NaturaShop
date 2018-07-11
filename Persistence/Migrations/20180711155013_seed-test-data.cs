using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class seedtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Sales",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { 2, "TestCustomer", 7L });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { 3, "TestPartner", 7L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 4, "TestProduct", 3m });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Date", "PartnerId", "ProductId", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 1, 2, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 3, 4, 1, 3m, 5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
