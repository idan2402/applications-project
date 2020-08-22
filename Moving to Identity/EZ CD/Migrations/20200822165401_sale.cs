using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EZ_CD.Migrations
{
    public partial class sale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    addr = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });
            migrationBuilder.CreateTable(
               name: "Sale",
               columns: table => new
               {
                   saleId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   customerId = table.Column<int>(nullable: true),
                   date = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Sale", x => x.saleId);
                   table.ForeignKey(
                       name: "FK_Sale_Customer_customerId",
                       column: x => x.customerId,
                       principalTable: "Customer",
                       principalColumn: "customerId",
                       onDelete: ReferentialAction.Restrict);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
