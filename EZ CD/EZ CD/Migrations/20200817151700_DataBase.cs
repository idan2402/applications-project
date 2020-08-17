using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    artistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    birthday = table.Column<DateTime>(nullable: false),
                    genre = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.artistId);
                });

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
                name: "Disk",
                columns: table => new
                {
                    diskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    artistId = table.Column<int>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    dateAdded = table.Column<DateTime>(nullable: false),
                    adminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disk", x => x.diskId);
                    table.ForeignKey(
                        name: "FK_Disk_Admin_adminId",
                        column: x => x.adminId,
                        principalTable: "Admin",
                        principalColumn: "adminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disk_Artist_artistId",
                        column: x => x.artistId,
                        principalTable: "Artist",
                        principalColumn: "artistId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    songId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    diskId = table.Column<int>(nullable: true),
                    length = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.songId);
                    table.ForeignKey(
                        name: "FK_Song_Disk_diskId",
                        column: x => x.diskId,
                        principalTable: "Disk",
                        principalColumn: "diskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetailes",
                columns: table => new
                {
                    diskId = table.Column<int>(nullable: false),
                    saleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetailes", x => new { x.diskId, x.saleId });
                    table.ForeignKey(
                        name: "FK_SaleDetailes_Disk_diskId",
                        column: x => x.diskId,
                        principalTable: "Disk",
                        principalColumn: "diskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetailes_Sale_saleId",
                        column: x => x.saleId,
                        principalTable: "Sale",
                        principalColumn: "saleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disk_adminId",
                table: "Disk",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_Disk_artistId",
                table: "Disk",
                column: "artistId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_customerId",
                table: "Sale",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailes_saleId",
                table: "SaleDetailes",
                column: "saleId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_diskId",
                table: "Song",
                column: "diskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetailes");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Disk");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
