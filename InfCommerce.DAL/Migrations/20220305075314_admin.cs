﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    MailAddress = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "char(32)", maxLength: 32, nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastIPNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "LastDate", "LastIPNo", "MailAddress", "NameSurname", "Password" },
                values: new object[] { 1, new DateTime(2022, 3, 5, 10, 53, 13, 602, DateTimeKind.Local).AddTicks(4535), "1", "bekir@gmail.com", "Bekir Oturakçı", "202cb962ac59075b964b07152d234b70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
