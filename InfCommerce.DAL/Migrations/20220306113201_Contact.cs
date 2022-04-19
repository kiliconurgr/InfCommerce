using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    MailAddress = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    Subject = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 6, 14, 32, 0, 597, DateTimeKind.Local).AddTicks(6517));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 6, 12, 56, 30, 116, DateTimeKind.Local).AddTicks(840));
        }
    }
}
