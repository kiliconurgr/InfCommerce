using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Distinct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distinct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Distinct_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 12, 12, 44, 53, 91, DateTimeKind.Local).AddTicks(7144));

            migrationBuilder.CreateIndex(
                name: "IX_Distinct_CityID",
                table: "Distinct",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distinct");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 3, 12, 12, 27, 31, 147, DateTimeKind.Local).AddTicks(1635));
        }
    }
}
