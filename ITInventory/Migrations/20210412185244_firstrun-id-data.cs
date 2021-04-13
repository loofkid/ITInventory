using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class firstruniddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID",
                schema: "Setup",
                table: "FirstRun",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstRun",
                schema: "Setup",
                table: "FirstRun",
                column: "ID");

            migrationBuilder.InsertData(
                schema: "Setup",
                table: "FirstRun",
                columns: new[] { "ID", "IsFirstRun", "SetupCompleted", "SetupStep" },
                values: new object[] { "firstrun", true, false, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstRun",
                schema: "Setup",
                table: "FirstRun");

            migrationBuilder.DeleteData(
                schema: "Setup",
                table: "FirstRun",
                keyColumn: "ID",
                keyColumnType: "nvarchar(450)",
                keyValue: "firstrun");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "Setup",
                table: "FirstRun");
        }
    }
}
