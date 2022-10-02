using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_Project.Migrations
{
    public partial class addingInitialWeights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Weights",
                columns: new[] { "Id", "ExtraCostPerKG", "NormalCost", "NormalWeight" },
                values: new object[] { 1, 5m, 5m, 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Weights",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
