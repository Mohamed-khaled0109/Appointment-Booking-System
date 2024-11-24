using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_users_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_users_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "appointmentId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "scheduleId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_appointmentId",
                table: "users",
                column: "appointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_users_scheduleId",
                table: "users",
                column: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Appointments_appointmentId",
                table: "users",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Schedules_scheduleId",
                table: "users",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Appointments_appointmentId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Schedules_scheduleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_appointmentId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_scheduleId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "appointmentId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "scheduleId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_users_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
