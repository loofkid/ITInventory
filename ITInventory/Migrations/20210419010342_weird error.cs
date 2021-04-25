using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class weirderror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboBoxItems_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropIndex(
                name: "IX_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropColumn(
                name: "ManufacturerName",
                schema: "Metadata",
                table: "ComboBoxItems");

            migrationBuilder.DropColumn(
                name: "ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManufacturerName",
                schema: "Metadata",
                table: "ComboBoxItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                columns: new[] { "ManufacturerName", "ManufacturerUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComboBoxItems_ComboBoxItems_ManufacturerName_ManufacturerUserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                columns: new[] { "ManufacturerName", "ManufacturerUserId" },
                principalSchema: "Metadata",
                principalTable: "ComboBoxItems",
                principalColumns: new[] { "Name", "UserId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
