using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WasteGoalsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteReports_AspNetUsers_AppUserId",
                table: "WasteReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteReports",
                table: "WasteReports");

            migrationBuilder.RenameTable(
                name: "WasteReports",
                newName: "WasteReport");

            migrationBuilder.RenameIndex(
                name: "IX_WasteReports_AppUserId",
                table: "WasteReport",
                newName: "IX_WasteReport_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteReport",
                table: "WasteReport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WasteGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: true),
                    TargetPlastic = table.Column<float>(type: "REAL", nullable: false),
                    TargetPaper = table.Column<float>(type: "REAL", nullable: false),
                    TargetWater = table.Column<float>(type: "REAL", nullable: false),
                    TargetFood = table.Column<float>(type: "REAL", nullable: false),
                    TargetFuel = table.Column<float>(type: "REAL", nullable: false),
                    ProgressPlastic = table.Column<float>(type: "REAL", nullable: false),
                    ProgressPaper = table.Column<float>(type: "REAL", nullable: false),
                    PrgressWater = table.Column<float>(type: "REAL", nullable: false),
                    PrgressFood = table.Column<float>(type: "REAL", nullable: false),
                    PrgressFuel = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteGoal_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WasteGoal_AppUserId",
                table: "WasteGoal",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteReport_AspNetUsers_AppUserId",
                table: "WasteReport",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteReport_AspNetUsers_AppUserId",
                table: "WasteReport");

            migrationBuilder.DropTable(
                name: "WasteGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteReport",
                table: "WasteReport");

            migrationBuilder.RenameTable(
                name: "WasteReport",
                newName: "WasteReports");

            migrationBuilder.RenameIndex(
                name: "IX_WasteReport_AppUserId",
                table: "WasteReports",
                newName: "IX_WasteReports_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteReports",
                table: "WasteReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteReports_AspNetUsers_AppUserId",
                table: "WasteReports",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
