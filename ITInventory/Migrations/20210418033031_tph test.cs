using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class tphtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Technicians_TechnicianId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Customers_CustomerId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Technicians",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ManagerId",
                schema: "Identity",
                table: "Users",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Users_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Users_TechnicianId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "TechnicianId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Users_CustomerId",
                schema: "Inventory",
                table: "InventoryItems",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ManagerId",
                schema: "Identity",
                table: "Users",
                column: "ManagerId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Users_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Users_TechnicianId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Users_CustomerId",
                schema: "Inventory",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ManagerId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ManagerId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Department",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                schema: "Identity",
                table: "Users");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ManagerId",
                schema: "Identity",
                table: "Customers",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Technicians_TechnicianId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "TechnicianId",
                principalSchema: "Identity",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Customers_CustomerId",
                schema: "Inventory",
                table: "InventoryItems",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
