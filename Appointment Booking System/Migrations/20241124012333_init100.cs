using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class init100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Appointments_AppointmentId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_AppointmentId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_UserId",
                table: "users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Appointments_UserId",
                table: "users",
                column: "UserId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Appointments_UserId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_AppointmentId",
                table: "users",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Appointments_AppointmentId",
                table: "users",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
