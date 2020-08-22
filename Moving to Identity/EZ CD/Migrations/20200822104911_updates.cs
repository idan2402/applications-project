using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Artist_artistId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Customer_customerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailes_Disk_diskId",
                table: "SaleDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailes_Sale_saleId",
                table: "SaleDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Disk_diskId",
                table: "Song");

            migrationBuilder.RenameColumn(
                name: "diskId",
                table: "Song",
                newName: "DiskId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_diskId",
                table: "Song",
                newName: "IX_Song_DiskId");

            migrationBuilder.RenameColumn(
                name: "saleId",
                table: "SaleDetailes",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "diskId",
                table: "SaleDetailes",
                newName: "DiskId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetailes_saleId",
                table: "SaleDetailes",
                newName: "IX_SaleDetailes_SaleId");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Sale",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_customerId",
                table: "Sale",
                newName: "IX_Sale_CustomerId");

            migrationBuilder.RenameColumn(
                name: "artistId",
                table: "Disk",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_artistId",
                table: "Disk",
                newName: "IX_Disk_ArtistId");

            migrationBuilder.AlterColumn<int>(
                name: "DiskId",
                table: "Song",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Disk",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Artist_ArtistId",
                table: "Disk",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "artistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailes_Disk_DiskId",
                table: "SaleDetailes",
                column: "DiskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailes_Sale_SaleId",
                table: "SaleDetailes",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "saleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Disk_DiskId",
                table: "Song",
                column: "DiskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Artist_ArtistId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Customer_CustomerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailes_Disk_DiskId",
                table: "SaleDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailes_Sale_SaleId",
                table: "SaleDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Disk_DiskId",
                table: "Song");

            migrationBuilder.RenameColumn(
                name: "DiskId",
                table: "Song",
                newName: "diskId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_DiskId",
                table: "Song",
                newName: "IX_Song_diskId");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "SaleDetailes",
                newName: "saleId");

            migrationBuilder.RenameColumn(
                name: "DiskId",
                table: "SaleDetailes",
                newName: "diskId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetailes_SaleId",
                table: "SaleDetailes",
                newName: "IX_SaleDetailes_saleId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Sale",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                newName: "IX_Sale_customerId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Disk",
                newName: "artistId");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_ArtistId",
                table: "Disk",
                newName: "IX_Disk_artistId");

            migrationBuilder.AlterColumn<int>(
                name: "diskId",
                table: "Song",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Disk",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Artist_artistId",
                table: "Disk",
                column: "artistId",
                principalTable: "Artist",
                principalColumn: "artistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Customer_customerId",
                table: "Sale",
                column: "customerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailes_Disk_diskId",
                table: "SaleDetailes",
                column: "diskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailes_Sale_saleId",
                table: "SaleDetailes",
                column: "saleId",
                principalTable: "Sale",
                principalColumn: "saleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Disk_diskId",
                table: "Song",
                column: "diskId",
                principalTable: "Disk",
                principalColumn: "diskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
