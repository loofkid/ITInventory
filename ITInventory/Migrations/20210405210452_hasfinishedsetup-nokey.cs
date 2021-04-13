using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class hasfinishedsetupnokey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Setup");

            migrationBuilder.CreateTable(
                name: "FirstRun",
                schema: "Setup",
                columns: table => new
                {
                    IsFirstRun = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstRun",
                schema: "Setup");
        }
    }
}
