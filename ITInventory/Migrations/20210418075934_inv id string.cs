using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class invidstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemReceipt_InventoryItems_InventoryItemsName",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "InventoryItemsName",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                newName: "InventoryItemsInventoryId");

            migrationBuilder.RenameColumn(
                name: "HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "HardwareItemInventoryId");

            migrationBuilder.RenameColumn(
                name: "InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckOutRecords_InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "IX_CheckOutRecords_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckOutRecords_HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "IX_CheckOutRecords_HardwareItemInventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "InventoryId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "InventoryId",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemReceipt_InventoryItems_InventoryItemsInventoryId",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                column: "InventoryItemsInventoryId",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemReceipt_InventoryItems_InventoryItemsInventoryId",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "InventoryItemsInventoryId",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                newName: "InventoryItemsName");

            migrationBuilder.RenameColumn(
                name: "HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "HardwareItemName");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "InventoryName");

            migrationBuilder.RenameIndex(
                name: "IX_CheckOutRecords_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "IX_CheckOutRecords_InventoryName");

            migrationBuilder.RenameIndex(
                name: "IX_CheckOutRecords_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                newName: "IX_CheckOutRecords_HardwareItemName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemName",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_InventoryItems_InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "InventoryName",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemReceipt_InventoryItems_InventoryItemsName",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                column: "InventoryItemsName",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
