using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class imagetableupdatesitesettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteLogo",
                schema: "Settings",
                table: "SiteSettings");

            migrationBuilder.EnsureSchema(
                name: "Content");

            migrationBuilder.AddColumn<int>(
                name: "SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Content",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings",
                column: "SiteLogoImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteSettings_Images_SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings",
                column: "SiteLogoImageID",
                principalSchema: "Content",
                principalTable: "Images",
                principalColumn: "ImageID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteSettings_Images_SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Content");

            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SiteLogoImageID",
                schema: "Settings",
                table: "SiteSettings");

            migrationBuilder.AddColumn<byte[]>(
                name: "SiteLogo",
                schema: "Settings",
                table: "SiteSettings",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
