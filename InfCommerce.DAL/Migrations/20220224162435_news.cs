using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
