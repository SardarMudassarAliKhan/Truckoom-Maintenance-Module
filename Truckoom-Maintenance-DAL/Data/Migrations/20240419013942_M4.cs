using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Truckoom_Maintenance.Data.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MaintenanceActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaintenanceActivities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaintenanceActivities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaintenanceActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MaintenanceActivities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MaintenanceActivities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaintenanceActivities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaintenanceActivities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MaintenanceActivities");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MaintenanceActivities");
        }
    }
}
