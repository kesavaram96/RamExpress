using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RamExpress.Migrations
{
    public partial class card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantitive",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantitive",
                table: "Card");
        }
    }
}
