using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace EZ_CD.Migrations
{
    public partial class updatecustomeragain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addr",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "addr",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
