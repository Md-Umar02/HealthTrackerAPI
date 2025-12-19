using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHealthMetricModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebugColumn",
                table: "HealthMetrics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebugColumn",
                table: "HealthMetrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
