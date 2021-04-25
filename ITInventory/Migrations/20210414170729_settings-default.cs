using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class settingsdefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: 1);

            migrationBuilder.InsertData(
                schema: "Settings",
                table: "SiteSettings",
                columns: new[] { "SiteID", "SiteColorPrimary", "SiteColorSecondary", "SiteLogoImageID" },
                values: new object[] { -1, "0275d8", "6C757D", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: -1);

            migrationBuilder.InsertData(
                schema: "Settings",
                table: "SiteSettings",
                columns: new[] { "SiteID", "SiteColorPrimary", "SiteColorSecondary", "SiteLogoImageID" },
                values: new object[] { 1, "0275d8", "6C757D", null });
        }
    }
}
