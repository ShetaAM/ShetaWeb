using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheta.Data.Migrations
{
    public partial class PROD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_TeacherId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TeacherId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TeacherId",
                table: "Products",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_TeacherId",
                table: "Products",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
