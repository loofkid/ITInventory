using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class weightedcomboboxitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropColumn(
                name: "PhysicalLocation",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.EnsureSchema(
                name: "Metadata");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Category_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ItemModel_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalLocation",
                schema: "Metadata",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalLocation", x => x.Name);
                    table.ForeignKey(
                        name: "FK_PhysicalLocation_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "ItemModel",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "PhysicalLocation",
                schema: "Metadata");

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

            migrationBuilder.DropColumn(
                name: "CategoryName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ManufacturerName",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModelName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.DropColumn(
                name: "PhysicalLocationName",
                schema: "Inventory",
                table: "HardwareItems");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                schema: "Inventory",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocation",
                schema: "Inventory",
                table: "HardwareItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
