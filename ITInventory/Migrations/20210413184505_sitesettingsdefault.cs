using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class sitesettingsdefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Settings");

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                schema: "Settings",
                columns: table => new
                {
                    SiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteColorPrimary = table.Column<int>(type: "int", nullable: false),
                    SiteColorSecondary = table.Column<int>(type: "int", nullable: false),
                    SiteLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteID);
                });

            migrationBuilder.InsertData(
                schema: "Settings",
                table: "SiteSettings",
                columns: new[] { "SiteID", "SiteColorPrimary", "SiteColorSecondary", "SiteLogo" },
                values: new object[] { 1, 161240, 7107965, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSettings",
                schema: "Settings");
        }
    }
}
