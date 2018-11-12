using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class jointable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ProductId",
                table: "Sales");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Sales");

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    SaleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => new { x.SaleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SaleProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "LastModified", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 26, 8, 17, 26, 240, DateTimeKind.Local), "TestProduct", 3m },
                    { 2, new DateTime(2018, 7, 25, 8, 17, 26, 240, DateTimeKind.Local), "TestProduct2", 2m }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "TotalPrice" },
                values: new object[] { new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), 0m });

            migrationBuilder.InsertData(
                table: "SaleProduct",
                columns: new[] { "SaleId", "ProductId", "LastModified" },
                values: new object[] { 1, 1, new DateTime(2018, 7, 26, 8, 17, 26, 248, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "SaleProduct",
                columns: new[] { "SaleId", "ProductId", "LastModified" },
                values: new object[] { 1, 2, new DateTime(2018, 7, 26, 8, 17, 26, 248, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Sales",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2018, 7, 18, 10, 6, 28, 185, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2018, 7, 18, 10, 6, 28, 188, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "LastModified", "Name", "Price" },
                values: new object[] { 4, new DateTime(2018, 7, 18, 10, 6, 28, 191, DateTimeKind.Local), "TestProduct", 3m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LastModified", "ProductId", "TotalPrice", "UnitPrice" },
                values: new object[] { new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 4, 3m, 5m });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
