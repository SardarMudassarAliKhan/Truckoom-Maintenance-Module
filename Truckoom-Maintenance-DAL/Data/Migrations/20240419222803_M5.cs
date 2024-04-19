using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Truckoom_Maintenance.Data.Migrations
{
    /// <inheritdoc />
    public partial class M5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "MaintenanceActivities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceActivities_UsersId",
                table: "MaintenanceActivities",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceActivities_AspNetUsers_UsersId",
                table: "MaintenanceActivities",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceActivities_AspNetUsers_UsersId",
                table: "MaintenanceActivities");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceActivities_UsersId",
                table: "MaintenanceActivities");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "MaintenanceActivities");
        }
    }
}
