using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class cretedcontrollers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "Disk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videoUrl",
                table: "Disk",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "videoUrl",
                table: "Disk");
        }
    }
}
