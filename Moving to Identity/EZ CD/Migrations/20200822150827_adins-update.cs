using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ_CD.Migrations
{
    public partial class adinsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Admin");
            migrationBuilder.DropColumn(
                name: "password",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Admin");
            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateAdded",
                table: "Admin",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "theUserId",
                table: "Admin",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "whoAddedadminId",
                table: "Admin",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_theUserId",
                table: "Admin",
                column: "theUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_whoAddedadminId",
                table: "Admin",
                column: "whoAddedadminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_theUserId",
                table: "Admin",
                column: "theUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Admin_whoAddedadminId",
                table: "Admin",
                column: "whoAddedadminId",
                principalTable: "Admin",
                principalColumn: "adminId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_theUserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Admin_whoAddedadminId",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_theUserId",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_whoAddedadminId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "dateAdded",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "theUserId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "whoAddedadminId",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
