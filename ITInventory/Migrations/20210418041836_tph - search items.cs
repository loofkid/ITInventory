using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class tphsearchitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Category_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Manufacturer_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "CellPhoneItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "SoftwareItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "HardwareItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "ItemModel",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "PhysicalLocation",
                schema: "Metadata");

            migrationBuilder.AddColumn<bool>(
                name: "CanTakeHome",
                schema: "Inventory",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IMEINumber",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseKey",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelUserId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Physical",
                schema: "Inventory",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocationName",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresApproval",
                schema: "Inventory",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoftwareLocation",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Subscription",
                schema: "Inventory",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubscriptionCost",
                schema: "Inventory",
                table: "InventoryItems",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyExpiration",
                schema: "Inventory",
                table: "InventoryItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Metadata",
                table: "ComboBoxItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "ModelName", "ModelUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "PhysicalLocationName", "PhysicalLocationUserId" });

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
                name: "FK_InventoryItems_ComboBoxItems_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "CategoryName", "CategoryUserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "ManufacturerName", "ManufacturerUserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "ModelName", "ModelUserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "PhysicalLocationName", "PhysicalLocationUserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_InventoryItems_ComboBoxItems_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_ComboBoxItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CanTakeHome",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IMEINumber",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LicenseKey",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModelName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModelUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Physical",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "PhysicalLocationName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "PhysicalLocationUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "RequiresApproval",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "SoftwareLocation",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Subscription",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "SubscriptionCost",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "WarrantyExpiration",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => new { x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_Category_ComboBoxItems_Name_UserId",
                        columns: x => new { x.Name, x.UserId },
                        principalSchema: "Metadata",
                        principalTable: "ComboBoxItems",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => new { x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_ItemModel_ComboBoxItems_Name_UserId",
                        columns: x => new { x.Name, x.UserId },
                        principalSchema: "Metadata",
                        principalTable: "ComboBoxItems",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemModel_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => new { x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_Manufacturer_ComboBoxItems_Name_UserId",
                        columns: x => new { x.Name, x.UserId },
                        principalSchema: "Metadata",
                        principalTable: "ComboBoxItems",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalLocation",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalLocation", x => new { x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_PhysicalLocation_ComboBoxItems_Name_UserId",
                        columns: x => new { x.Name, x.UserId },
                        principalSchema: "Metadata",
                        principalTable: "ComboBoxItems",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalLocation_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    LicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Physical = table.Column<bool>(type: "bit", nullable: false),
                    SoftwareLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subscription = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionCost = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareItems", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_SoftwareItems_InventoryItems_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    CanTakeHome = table.Column<bool>(type: "bit", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModelUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhysicalLocationName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhysicalLocationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareItems", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_HardwareItems_InventoryItems_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareItems_ItemModel_ModelName_ModelUserId",
                        columns: x => new { x.ModelName, x.ModelUserId },
                        principalSchema: "Metadata",
                        principalTable: "ItemModel",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareItems_PhysicalLocation_PhysicalLocationName_PhysicalLocationUserId",
                        columns: x => new { x.PhysicalLocationName, x.PhysicalLocationUserId },
                        principalSchema: "Metadata",
                        principalTable: "PhysicalLocation",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CellPhoneItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    IMEINumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellPhoneItems", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_CellPhoneItems_HardwareItems_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "Inventory",
                        principalTable: "HardwareItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "HardwareItems",
                columns: new[] { "ModelName", "ModelUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems",
                columns: new[] { "PhysicalLocationName", "PhysicalLocationUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_UserId",
                schema: "Metadata",
                table: "ItemModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_UserId",
                schema: "Metadata",
                table: "Manufacturer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalLocation_UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_HardwareItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "HardwareItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "HardwareItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "InventoryId",
                principalSchema: "Inventory",
                principalTable: "HardwareItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Category_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "CategoryName", "CategoryUserId" },
                principalSchema: "Metadata",
                principalTable: "Category",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Manufacturer_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "ManufacturerName", "ManufacturerUserId" },
                principalSchema: "Metadata",
                principalTable: "Manufacturer",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
