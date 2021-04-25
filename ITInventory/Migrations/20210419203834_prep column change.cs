using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class prepcolumnchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Receipts_FileData",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "Inventory",
                table: "Receipts",
                type: "varbinary(MAX)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(900)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfPurchase",
                schema: "Inventory",
                table: "InventoryItems",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "Inventory",
                table: "Receipts",
                type: "varbinary(900)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfPurchase",
                schema: "Inventory",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Receipts_FileData",
                schema: "Inventory",
                table: "Receipts",
                column: "FileData");
        }
    }
}
