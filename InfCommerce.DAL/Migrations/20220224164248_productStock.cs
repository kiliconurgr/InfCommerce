using Microsoft.EntityFrameworkCore.Migrations;

namespace InfCommerce.DAL.Migrations
{
    public partial class productStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Product");
        }
    }
}
