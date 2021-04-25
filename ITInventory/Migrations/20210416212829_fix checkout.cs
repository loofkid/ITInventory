using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class fixcheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.AddColumn<int>(
                name: "HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CheckOutTime");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "HardwareItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "InventoryID", "CheckOutTime" });
        }
    }
}
