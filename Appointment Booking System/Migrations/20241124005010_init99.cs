using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class init99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Appointments_appointmentId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "appointmentId",
                table: "users",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_users_appointmentId",
                table: "users",
                newName: "IX_users_AppointmentId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Appointments_AppointmentId",
                table: "users",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Appointments_AppointmentId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "users",
                newName: "appointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_users_AppointmentId",
                table: "users",
                newName: "IX_users_appointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Appointments_appointmentId",
                table: "users",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
