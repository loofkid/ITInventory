using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class inheritanceschemaandothermodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Customers_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "Identity",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_Id",
                        column: x => x.Id,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    SupportExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RenewSupport = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technicians_Customers_Id",
                        column: x => x.Id,
                        principalSchema: "Identity",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhysicalLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanTakeHome = table.Column<bool>(type: "bit", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                schema: "Inventory",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemInventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Receipts_InventoryItems_ItemInventoryId",
                        column: x => x.ItemInventoryId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareItems",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    LicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftwareLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Physical = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CheckOutRecords",
                schema: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemInventoryId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApproverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReturnTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutRecords", x => new { x.InventoryID, x.CheckOutTime });
                    table.ForeignKey(
                        name: "FK_CheckOutRecords_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOutRecords_HardwareItems_ItemInventoryId",
                        column: x => x.ItemInventoryId,
                        principalSchema: "Inventory",
                        principalTable: "HardwareItems",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOutRecords_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalSchema: "Identity",
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOutRecords_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_ApproverId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_ItemInventoryId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "ItemInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutRecords_TechnicianId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ManagerId",
                schema: "Identity",
                table: "Customers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CustomerId",
                schema: "Inventory",
                table: "InventoryItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ItemInventoryId",
                schema: "Inventory",
                table: "Receipts",
                column: "ItemInventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellPhoneItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "CheckOutRecords",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Receipts",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SoftwareItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "HardwareItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Technicians",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InventoryItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Identity");
        }
    }
}
