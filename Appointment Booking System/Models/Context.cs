using Microsoft.EntityFrameworkCore;

namespace Appointment_Booking_System.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions option):base(option) 
        { }
        
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Users>users { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
    }
}
