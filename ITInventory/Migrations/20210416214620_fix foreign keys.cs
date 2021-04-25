using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class fixforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_ComboBoxItems_Name",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboBoxItems_Users_UserId",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_ItemModel_ModelName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_PhysicalLocation_PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Category_CategoryName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Manufacturer_ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_ComboBoxItems_Name",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_ComboBoxItems_Name",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalLocation_ComboBoxItems_Name",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_InventoryItems_ItemInventoryId",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicalLocation",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModel",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CategoryName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_HardwareItems_ModelName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropIndex(
                name: "IX_HardwareItems_PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboBoxItems",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.RenameColumn(
                name: "ItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                newName: "InventoryItemInventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                newName: "IX_Receipts_InventoryItemInventoryId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                schema: "Inventory",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "Manufacturer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "ItemModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelUserId",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicalLocation",
                schema: "Metadata",
                table: "PhysicalLocation",
                columns: new[] { "Name", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                schema: "Metadata",
                table: "Manufacturer",
                columns: new[] { "Name", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModel",
                schema: "Metadata",
                table: "ItemModel",
                columns: new[] { "Name", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboBoxItems",
                schema: "Metadata",
                table: "ComboBoxItems",
                columns: new[] { "Name", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "CheckOutTime", "InventoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "Metadata",
                table: "Category",
                columns: new[] { "Name", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalLocation_UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_UserId",
                schema: "Metadata",
                table: "Manufacturer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_UserId",
                schema: "Metadata",
                table: "ItemModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "CategoryName", "CategoryUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems",
                columns: new[] { "ManufacturerName", "ManufacturerUserId" });

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
                name: "IX_CheckOutRecords_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "Category",
                columns: new[] { "Name", "UserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Users_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ComboBoxItems_Users_UserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_ItemModel_ModelName_ModelUserId",
                schema: "Inventory",
                table: "HardwareItems",
                columns: new[] { "ModelName", "ModelUserId" },
                principalSchema: "Metadata",
                principalTable: "ItemModel",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_PhysicalLocation_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems",
                columns: new[] { "PhysicalLocationName", "PhysicalLocationUserId" },
                principalSchema: "Metadata",
                principalTable: "PhysicalLocation",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "ItemModel",
                columns: new[] { "Name", "UserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_Users_UserId",
                schema: "Metadata",
                table: "ItemModel",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "Manufacturer",
                columns: new[] { "Name", "UserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_Users_UserId",
                schema: "Metadata",
                table: "Manufacturer",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalLocation_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                columns: new[] { "Name", "UserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalLocation_Users_UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Users_UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboBoxItems_Users_UserId",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_ItemModel_ModelName_ModelUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_PhysicalLocation_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Category_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Manufacturer_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_Users_UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_Users_UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalLocation_ComboBoxItems_Name_UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalLocation_Users_UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_InventoryItems_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicalLocation",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalLocation_UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturer_UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModel",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_ItemModel_UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CategoryName_CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_ManufacturerName_ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_HardwareItems_ModelName_ModelUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropIndex(
                name: "IX_HardwareItems_PhysicalLocationName_PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboBoxItems",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutRecords_InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                schema: "Inventory",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "CategoryUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ManufacturerUserId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModelUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropColumn(
                name: "PhysicalLocationUserId",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                newName: "ItemInventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_InventoryItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                newName: "IX_Receipts_ItemInventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicalLocation",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                schema: "Metadata",
                table: "Manufacturer",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModel",
                schema: "Metadata",
                table: "ItemModel",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboBoxItems",
                schema: "Metadata",
                table: "ComboBoxItems",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CheckOutTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "Metadata",
                table: "Category",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryName",
                schema: "Inventory",
                table: "InventoryItems",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems",
                column: "ManufacturerName");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_ModelName",
                schema: "Inventory",
                table: "HardwareItems",
                column: "ModelName");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems",
                column: "PhysicalLocationName");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "ItemInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_ComboBoxItems_Name",
                schema: "Metadata",
                table: "Category",
                column: "Name",
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_HardwareItems_ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "ItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "HardwareItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboBoxItems_Users_UserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_ItemModel_ModelName",
                schema: "Inventory",
                table: "HardwareItems",
                column: "ModelName",
                principalSchema: "Metadata",
                principalTable: "ItemModel",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_PhysicalLocation_PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems",
                column: "PhysicalLocationName",
                principalSchema: "Metadata",
                principalTable: "PhysicalLocation",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Category_CategoryName",
                schema: "Inventory",
                table: "InventoryItems",
                column: "CategoryName",
                principalSchema: "Metadata",
                principalTable: "Category",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Manufacturer_ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems",
                column: "ManufacturerName",
                principalSchema: "Metadata",
                principalTable: "Manufacturer",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_ComboBoxItems_Name",
                schema: "Metadata",
                table: "ItemModel",
                column: "Name",
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_ComboBoxItems_Name",
                schema: "Metadata",
                table: "Manufacturer",
                column: "Name",
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalLocation_ComboBoxItems_Name",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "Name",
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_InventoryItems_ItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                column: "ItemInventoryId",
                principalSchema: "Inventory",
                principalTable: "InventoryItems",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
