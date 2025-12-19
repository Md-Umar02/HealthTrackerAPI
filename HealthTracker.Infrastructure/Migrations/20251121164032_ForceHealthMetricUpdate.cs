using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForceHealthMetricUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedAt",
                table: "HealthMetrics");

            migrationBuilder.AddColumn<string>(
                name: "DebugColumn",
                table: "HealthMetrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebugColumn",
                table: "HealthMetrics");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedAt",
                table: "HealthMetrics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
