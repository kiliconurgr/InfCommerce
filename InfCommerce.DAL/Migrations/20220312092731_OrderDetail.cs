﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class OrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    NameSurname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TaxOffice = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    MailAddress = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DeliveryCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DeliveryDistinct = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DeliveryZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    BilingAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    BilingCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BilingDistinct = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BilingZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductPicture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 12, 12, 27, 31, 147, DateTimeKind.Local).AddTicks(1635));

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderNumber",
                table: "Order",
                column: "OrderNumber",
                unique: true,
                filter: "[OrderNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 6, 14, 32, 0, 597, DateTimeKind.Local).AddTicks(6517));
        }
    }
}
