using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Appointment_Booking_System.Models
{
    public class Appointment
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string state {  get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("User")]
        // public int UserId { get; set; }
        
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual List < Users>? users { get; set; }
    }
}
