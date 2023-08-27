using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WasteGoalFixnaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrgressWater",
                table: "WasteGoals",
                newName: "ProgressWater");

            migrationBuilder.RenameColumn(
                name: "PrgressFuel",
                table: "WasteGoals",
                newName: "ProgressFuel");

            migrationBuilder.RenameColumn(
                name: "PrgressFood",
                table: "WasteGoals",
                newName: "ProgressFood");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProgressWater",
                table: "WasteGoals",
                newName: "PrgressWater");

            migrationBuilder.RenameColumn(
                name: "ProgressFuel",
                table: "WasteGoals",
                newName: "PrgressFuel");

            migrationBuilder.RenameColumn(
                name: "ProgressFood",
                table: "WasteGoals",
                newName: "PrgressFood");
        }
    }
}
