using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class invidremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItemReceipt",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "InventoryItemsInventoryId",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

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

            migrationBuilder.AddColumn<string>(
                name: "InventoryItemsName",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItemReceipt",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                columns: new[] { "InventoryItemsName", "ReceiptsDocumentID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "CheckOutTime", "InventoryName", "CustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemName");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "InventoryName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItemReceipt",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "InventoryItemsName",
                schema: "Inventory",
                table: "InventoryItemReceipt");

            migrationBuilder.DropColumn(
                name: "InventoryName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "HardwareItemName",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemsInventoryId",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                schema: "Inventory",
                table: "InventoryItems",
                column: "InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItemReceipt",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                columns: new[] { "InventoryItemsInventoryId", "ReceiptsDocumentID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "CheckOutTime", "InventoryId", "CustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
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
    }
}
