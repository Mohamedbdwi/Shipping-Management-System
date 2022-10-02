using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_Project.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders",
                column: "Pro_Id",
                unique: true,
                filter: "[Pro_Id] IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Pro_Id",
                table: "Orders",
                column: "Pro_Id");
        }
    }
}
