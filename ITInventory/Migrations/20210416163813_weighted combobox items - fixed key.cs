using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class weightedcomboboxitemsfixedkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Users_UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_Users_UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_Users_UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalLocation_Users_UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalLocation_UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturer_UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_ItemModel_UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LastUsed",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropColumn(
                name: "Uses",
                schema: "Metadata",
                table: "PhysicalLocation");

            migrationBuilder.DropColumn(
                name: "LastUsed",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "Uses",
                schema: "Metadata",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "LastUsed",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "Uses",
                schema: "Metadata",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "LastUsed",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Uses",
                schema: "Metadata",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "ComboBoxItems",
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
                    table.PrimaryKey("PK_ComboBoxItems", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ComboBoxItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboBoxItems_UserId",
                schema: "Metadata",
                table: "ComboBoxItems",
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_ComboBoxItems_Name",
                schema: "Metadata",
                table: "Category");

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

            migrationBuilder.DropTable(
                name: "ComboBoxItems",
                schema: "Metadata");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUsed",
                schema: "Metadata",
                table: "PhysicalLocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uses",
                schema: "Metadata",
                table: "PhysicalLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUsed",
                schema: "Metadata",
                table: "Manufacturer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "Manufacturer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uses",
                schema: "Metadata",
                table: "Manufacturer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUsed",
                schema: "Metadata",
                table: "ItemModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "ItemModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uses",
                schema: "Metadata",
                table: "ItemModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUsed",
                schema: "Metadata",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Metadata",
                table: "Category",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uses",
                schema: "Metadata",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Category_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Users_UserId",
                schema: "Metadata",
                table: "Category",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_Users_UserId",
                schema: "Metadata",
                table: "ItemModel",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_Users_UserId",
                schema: "Metadata",
                table: "Manufacturer",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalLocation_Users_UserId",
                schema: "Metadata",
                table: "PhysicalLocation",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
