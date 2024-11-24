using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Appointment_Booking_System.Models
{
    public class Schedule
    {
        [JsonIgnore]
        public int Id { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }
        public int DayOfWeek { get; set; } 
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }
        
        [JsonIgnore]
        public virtual List<Users>? users { get; set; }  
    }
}
