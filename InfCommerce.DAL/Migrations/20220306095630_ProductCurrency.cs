using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class ProductCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 6, 12, 56, 30, 116, DateTimeKind.Local).AddTicks(840));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 5, 10, 53, 13, 602, DateTimeKind.Local).AddTicks(4535));
        }
    }
}
