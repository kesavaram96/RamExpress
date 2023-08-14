using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RamExpress.Migrations
{
    public partial class categoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categoriest_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoriest",
                table: "Categoriest");

            migrationBuilder.RenameTable(
                name: "Categoriest",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categoriest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoriest",
                table: "Categoriest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categoriest_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categoriest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
