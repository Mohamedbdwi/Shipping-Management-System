using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_Project.Migrations
{
    public partial class nullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Weights_Wt_Id",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Wt_Id",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Weights_Wt_Id",
                table: "Products",
                column: "Wt_Id",
                principalTable: "Weights",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_Pro_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Weights_Wt_Id",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Wt_Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Weights_Wt_Id",
                table: "Products",
                column: "Wt_Id",
                principalTable: "Weights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
