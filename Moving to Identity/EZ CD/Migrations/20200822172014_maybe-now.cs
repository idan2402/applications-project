using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class maybenow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "SaleDetailes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailes_customerId",
                table: "SaleDetailes",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailes_Customer_customerId",
                table: "SaleDetailes",
                column: "customerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailes_Customer_customerId",
                table: "SaleDetailes");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetailes_customerId",
                table: "SaleDetailes");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "SaleDetailes");
        }
    }
}
