using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class addcustomeridtocheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "CheckOutTime", "InventoryId", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckOutRecords",
                schema: "Inventory",
                table: "CheckOutRecords",
                columns: new[] { "CheckOutTime", "InventoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutRecords_Customers_CustomerId",
                schema: "Inventory",
                table: "CheckOutRecords",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
