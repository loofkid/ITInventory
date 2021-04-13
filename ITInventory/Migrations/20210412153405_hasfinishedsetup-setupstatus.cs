using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class hasfinishedsetupsetupstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SetupCompleted",
                schema: "Setup",
                table: "FirstRun",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SetupStep",
                schema: "Setup",
                table: "FirstRun",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetupCompleted",
                schema: "Setup",
                table: "FirstRun");

            migrationBuilder.DropColumn(
                name: "SetupStep",
                schema: "Setup",
                table: "FirstRun");
        }
    }
}
