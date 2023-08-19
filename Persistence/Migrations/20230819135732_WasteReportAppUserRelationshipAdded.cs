using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WasteReportAppUserRelationshipAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteReports_AspNetUsers_ReporterId",
                table: "WasteReports");

            migrationBuilder.DropIndex(
                name: "IX_WasteReports_ReporterId",
                table: "WasteReports");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "WasteReports");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "WasteReports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WasteReports_AppUserId",
                table: "WasteReports",
                column: "AppUserId");

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
                name: "FK_WasteReports_AspNetUsers_AppUserId",
                table: "WasteReports");

            migrationBuilder.DropIndex(
                name: "IX_WasteReports_AppUserId",
                table: "WasteReports");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "WasteReports");

            migrationBuilder.AddColumn<string>(
                name: "ReporterId",
                table: "WasteReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WasteReports_ReporterId",
                table: "WasteReports",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteReports_AspNetUsers_ReporterId",
                table: "WasteReports",
                column: "ReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
