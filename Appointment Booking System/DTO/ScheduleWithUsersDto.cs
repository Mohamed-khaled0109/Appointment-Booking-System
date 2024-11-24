using Appointment_Booking_System.Models;

namespace Appointment_Booking_System.DTO
{
    public class ScheduleWithUsersDto
    {
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> Users { get; set; }=new List<string>();
    }
}
