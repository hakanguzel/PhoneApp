using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneApp.Core.Infrastructure.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportDetailEntity_Reports_ReportId",
                table: "ReportDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDetailEntity",
                table: "ReportDetailEntity");

            migrationBuilder.RenameTable(
                name: "ReportDetailEntity",
                newName: "ReportDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ReportDetailEntity_ReportId",
                table: "ReportDetails",
                newName: "IX_ReportDetails_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDetails",
                table: "ReportDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDetails_Reports_ReportId",
                table: "ReportDetails",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportDetails_Reports_ReportId",
                table: "ReportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDetails",
                table: "ReportDetails");

            migrationBuilder.RenameTable(
                name: "ReportDetails",
                newName: "ReportDetailEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetailEntity",
                newName: "IX_ReportDetailEntity_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDetailEntity",
                table: "ReportDetailEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDetailEntity_Reports_ReportId",
                table: "ReportDetailEntity",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
