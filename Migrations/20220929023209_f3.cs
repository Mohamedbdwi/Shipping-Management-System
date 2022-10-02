using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_Project.Migrations
{
    public partial class f3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Pro_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "Pro_Id",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders",
                column: "Pro_Id",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
