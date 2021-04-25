using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class sitesettingscolorstings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteColorSecondary",
                schema: "Settings",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SiteColorPrimary",
                schema: "Settings",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: 1,
                columns: new[] { "SiteColorPrimary", "SiteColorSecondary" },
                values: new object[] { "0275d8", "6C757D" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SiteColorSecondary",
                schema: "Settings",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiteColorPrimary",
                schema: "Settings",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: 1,
                columns: new[] { "SiteColorPrimary", "SiteColorSecondary" },
                values: new object[] { 161240, 7107965 });
        }
    }
}
