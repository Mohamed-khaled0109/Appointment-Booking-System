using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointment_Booking_System.Models
{
    public class Users
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword {  get; set; }
        [Required]
        public int AppointmentId {  get; set; }
        public int scheduleId { get; set; }
        [JsonIgnore]
        public  Appointment? appointment { get; set; }
        [JsonIgnore]
        public  Schedule? schedule { get; set; }
    }
}
