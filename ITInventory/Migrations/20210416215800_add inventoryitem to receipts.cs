using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class addinventoryitemtoreceipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_InventoryItems_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.CreateTable(
                name: "InventoryItemReceipt",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryItemsInventoryId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsDocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemReceipt", x => new { x.InventoryItemsInventoryId, x.ReceiptsDocumentID });
                    table.ForeignKey(
                        name: "FK_InventoryItemReceipt_InventoryItems_InventoryItemsInventoryId",
                        column: x => x.InventoryItemsInventoryId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItemReceipt_Receipts_ReceiptsDocumentID",
                        column: x => x.ReceiptsDocumentID,
                        principalSchema: "Inventory",
                        principalTable: "Receipts",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemReceipt_ReceiptsDocumentID",
                schema: "Inventory",
                table: "InventoryItemReceipt",
                column: "ReceiptsDocumentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItemReceipt",
                schema: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                column: "InventoryItemInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_InventoryItems_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                column: "InventoryItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
