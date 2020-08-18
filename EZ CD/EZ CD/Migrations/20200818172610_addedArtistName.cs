using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class addedArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Artist",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Artist");
        }
    }
}
