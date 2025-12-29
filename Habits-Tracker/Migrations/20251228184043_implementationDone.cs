using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habits_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class implementationDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetricDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitLogs_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyMetricValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricDefinitionId = table.Column<int>(type: "int", nullable: false),
                    MetricDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MetricValue = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMetricValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMetricValues_MetricDefinitions_MetricDefinitionId",
                        column: x => x.MetricDefinitionId,
                        principalTable: "MetricDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMetricValues_MetricDefinitionId_MetricDate",
                table: "DailyMetricValues",
                columns: new[] { "MetricDefinitionId", "MetricDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabitLogs_ActivityId_LogDate",
                table: "HabitLogs",
                columns: new[] { "ActivityId", "LogDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetricDefinitions_MetricName",
                table: "MetricDefinitions",
                column: "MetricName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMetricValues");

            migrationBuilder.DropTable(
                name: "HabitLogs");

            migrationBuilder.DropTable(
                name: "MetricDefinitions");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
