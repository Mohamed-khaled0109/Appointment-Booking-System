namespace Appointment_Booking_System.DTO
{
    public class GetAppointmentsWithUsersDto
    {
        public int Id { get; set; }
        public string state { get; set; }
        public DateTime Date { get; set; }
        public List<string> UsersName { get; set; }=new List<string>();


    }
}
