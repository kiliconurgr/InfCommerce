using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class slider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slogan = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Link = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
