using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class productDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Product",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Product");
        }
    }
}
