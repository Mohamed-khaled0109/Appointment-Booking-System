namespace Appointment_Booking_System.DTO
{
    public class GetUserWithAppointmentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentId { get; set; }
        public int scheduleId { get; set; }


    }
}
