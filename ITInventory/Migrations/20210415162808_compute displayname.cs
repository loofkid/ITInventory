using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class computedisplayname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: -1,
                columns: new[] { "SiteColorPrimary", "SiteColorSecondary" },
                values: new object[] { "#0275d8", "#6C757D" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]");

            migrationBuilder.UpdateData(
                schema: "Settings",
                table: "SiteSettings",
                keyColumn: "SiteID",
                keyValue: -1,
                columns: new[] { "SiteColorPrimary", "SiteColorSecondary" },
                values: new object[] { "0275d8", "6C757D" });
        }
    }
}
