using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_Project.Migrations
{
    public partial class addingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pro_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders",
                column: "Pro_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders",
                column: "Pro_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Pro_Id",
                table: "Orders");
        }
    }
}
