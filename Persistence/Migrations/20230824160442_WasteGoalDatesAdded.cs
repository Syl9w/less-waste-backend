using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WasteGoalDatesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteGoal_AspNetUsers_AppUserId",
                table: "WasteGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WasteReport_AspNetUsers_AppUserId",
                table: "WasteReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteReport",
                table: "WasteReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteGoal",
                table: "WasteGoal");

            migrationBuilder.RenameTable(
                name: "WasteReport",
                newName: "WasteReports");

            migrationBuilder.RenameTable(
                name: "WasteGoal",
                newName: "WasteGoals");

            migrationBuilder.RenameIndex(
                name: "IX_WasteReport_AppUserId",
                table: "WasteReports",
                newName: "IX_WasteReports_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WasteGoal_AppUserId",
                table: "WasteGoals",
                newName: "IX_WasteGoals_AppUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WasteGoals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "WasteGoals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteReports",
                table: "WasteReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteGoals",
                table: "WasteGoals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteGoals_AspNetUsers_AppUserId",
                table: "WasteGoals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteReports_AspNetUsers_AppUserId",
                table: "WasteReports",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteGoals_AspNetUsers_AppUserId",
                table: "WasteGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_WasteReports_AspNetUsers_AppUserId",
                table: "WasteReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteReports",
                table: "WasteReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteGoals",
                table: "WasteGoals");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WasteGoals");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "WasteGoals");

            migrationBuilder.RenameTable(
                name: "WasteReports",
                newName: "WasteReport");

            migrationBuilder.RenameTable(
                name: "WasteGoals",
                newName: "WasteGoal");

            migrationBuilder.RenameIndex(
                name: "IX_WasteReports_AppUserId",
                table: "WasteReport",
                newName: "IX_WasteReport_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WasteGoals_AppUserId",
                table: "WasteGoal",
                newName: "IX_WasteGoal_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteReport",
                table: "WasteReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteGoal",
                table: "WasteGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteGoal_AspNetUsers_AppUserId",
                table: "WasteGoal",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteReport_AspNetUsers_AppUserId",
                table: "WasteReport",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
