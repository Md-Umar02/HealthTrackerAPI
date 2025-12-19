using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMetricTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetricType",
                table: "HealthMetrics");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "HealthMetrics",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MetricTypeId",
                table: "HealthMetrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MetricTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthMetrics_MetricTypeId",
                table: "HealthMetrics",
                column: "MetricTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthMetrics_MetricTypes_MetricTypeId",
                table: "HealthMetrics",
                column: "MetricTypeId",
                principalTable: "MetricTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthMetrics_MetricTypes_MetricTypeId",
                table: "HealthMetrics");

            migrationBuilder.DropTable(
                name: "MetricTypes");

            migrationBuilder.DropIndex(
                name: "IX_HealthMetrics_MetricTypeId",
                table: "HealthMetrics");

            migrationBuilder.DropColumn(
                name: "MetricTypeId",
                table: "HealthMetrics");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "HealthMetrics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "MetricType",
                table: "HealthMetrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
