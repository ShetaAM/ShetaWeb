using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheta.Data.Migrations
{
    public partial class typeor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "OrderPosts");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "OrderPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderPostTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(maxLength: 150, nullable: false),
                    TypeIcon = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPostTypes", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPosts_TypeId",
                table: "OrderPosts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPosts_OrderPostTypes_TypeId",
                table: "OrderPosts",
                column: "TypeId",
                principalTable: "OrderPostTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPosts_OrderPostTypes_TypeId",
                table: "OrderPosts");

            migrationBuilder.DropTable(
                name: "OrderPostTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderPosts_TypeId",
                table: "OrderPosts");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "OrderPosts");

            migrationBuilder.AddColumn<string>(
                name: "IsPay",
                table: "OrderPosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
