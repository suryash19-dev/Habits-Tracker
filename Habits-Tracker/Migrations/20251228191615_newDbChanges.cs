using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habits_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class newDbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetricDate",
                table: "DailyMetricValues",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_DailyMetricValues_MetricDefinitionId_MetricDate",
                table: "DailyMetricValues",
                newName: "IX_DailyMetricValues_MetricDefinitionId_Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DailyMetricValues",
                newName: "MetricDate");

            migrationBuilder.RenameIndex(
                name: "IX_DailyMetricValues_MetricDefinitionId_Date",
                table: "DailyMetricValues",
                newName: "IX_DailyMetricValues_MetricDefinitionId_MetricDate");
        }
    }
}
