using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheta.Data.Migrations
{
    public partial class brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandsBrandId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brandses",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandTitle = table.Column<string>(maxLength: 200, nullable: false),
                    BrandImage = table.Column<string>(maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brandses", x => x.BrandId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandsBrandId",
                table: "Products",
                column: "BrandsBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brandses_BrandsBrandId",
                table: "Products",
                column: "BrandsBrandId",
                principalTable: "Brandses",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brandses_BrandsBrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brandses");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandsBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandsBrandId",
                table: "Products");
        }
    }
}
