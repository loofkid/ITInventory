using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class addfiletypetoreceipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "Inventory",
                table: "Receipts",
                type: "varbinary(900)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                schema: "Inventory",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Receipts_FileData",
                schema: "Inventory",
                table: "Receipts",
                column: "FileData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Receipts_FileData",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "FileType",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "Inventory",
                table: "Receipts",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(900)");
        }
    }
}
