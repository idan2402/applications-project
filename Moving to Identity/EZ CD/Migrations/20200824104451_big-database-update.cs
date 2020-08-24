using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class bigdatabaseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Artist_ArtistId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Admin_adminId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Customer_customerId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Disk_DiskId",
                table: "Song");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "SaleDetailes");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Disk_customerId",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "videoUrl",
                table: "Disk");

            migrationBuilder.RenameColumn(
                name: "DiskId",
                table: "Song",
                newName: "diskId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_DiskId",
                table: "Song",
                newName: "IX_Song_diskId");

            migrationBuilder.RenameColumn(
                name: "adminId",
                table: "Disk",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Disk",
                newName: "artistId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_adminId",
                table: "Disk",
                newName: "IX_Disk_AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_ArtistId",
                table: "Disk",
                newName: "IX_Disk_artistId");

            migrationBuilder.AlterColumn<int>(
                name: "diskId",
                table: "Song",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "Song",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videoUrl",
                table: "Song",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Disk",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Disk",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "featuredVideoUrl",
                table: "Disk",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaleItem",
                columns: table => new
                {
                    saleItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diskId = table.Column<int>(nullable: true),
                    saleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItem", x => x.saleItemId);
                    table.ForeignKey(
                        name: "FK_SaleItem_Disk_diskId",
                        column: x => x.diskId,
                        principalTable: "Disk",
                        principalColumn: "diskId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItem_Sale_saleId",
                        column: x => x.saleId,
                        principalTable: "Sale",
                        principalColumn: "saleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UserId",
                table: "Sale",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_diskId",
                table: "SaleItem",
                column: "diskId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_saleId",
                table: "SaleItem",
                column: "saleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_AspNetUsers_AdminId",
                table: "Disk",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Artist_artistId",
                table: "Disk",
                column: "artistId",
                principalTable: "Artist",
                principalColumn: "artistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_UserId",
                table: "Sale",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Disk_diskId",
                table: "Song",
                column: "diskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_AspNetUsers_AdminId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Artist_artistId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_UserId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Disk_diskId",
                table: "Song");

            migrationBuilder.DropTable(
                name: "SaleItem");

            migrationBuilder.DropIndex(
                name: "IX_Sale_UserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "videoUrl",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "featuredVideoUrl",
                table: "Disk");

            migrationBuilder.RenameColumn(
                name: "diskId",
                table: "Song",
                newName: "DiskId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_diskId",
                table: "Song",
                newName: "IX_Song_DiskId");

            migrationBuilder.RenameColumn(
                name: "artistId",
                table: "Disk",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Disk",
                newName: "adminId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_artistId",
                table: "Disk",
                newName: "IX_Disk_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_AdminId",
                table: "Disk",
                newName: "IX_Disk_adminId");

            migrationBuilder.AlterColumn<int>(
                name: "DiskId",
                table: "Song",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Disk",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "adminId",
                table: "Disk",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "Disk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videoUrl",
                table: "Disk",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    theUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    whoAddedadminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_theUserId",
                        column: x => x.theUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admin_Admin_whoAddedadminId",
                        column: x => x.whoAddedadminId,
                        principalTable: "Admin",
                        principalColumn: "adminId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    theUserId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetailes",
                columns: table => new
                {
                    DiskId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetailes", x => new { x.DiskId, x.SaleId });
                    table.ForeignKey(
                        name: "FK_SaleDetailes_Disk_DiskId",
                        column: x => x.DiskId,
                        principalTable: "Disk",
                        principalColumn: "diskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetailes_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "saleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetailes_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Disk_customerId",
                table: "Disk",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_theUserId",
                table: "Admin",
                column: "theUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_whoAddedadminId",
                table: "Admin",
                column: "whoAddedadminId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_userId",
                table: "Customer",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailes_SaleId",
                table: "SaleDetailes",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailes_customerId",
                table: "SaleDetailes",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Artist_ArtistId",
                table: "Disk",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "artistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Admin_adminId",
                table: "Disk",
                column: "adminId",
                principalTable: "Admin",
                principalColumn: "adminId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Customer_customerId",
                table: "Disk",
                column: "customerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Disk_DiskId",
                table: "Song",
                column: "DiskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
