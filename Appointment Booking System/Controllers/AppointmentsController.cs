using Microsoft.AspNetCore.Http;
using Appointment_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Appointment_Booking_System.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly Context context;

        public AppointmentsController(Context context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid == true)
            {
                var appointments=context.Appointments.Include(u => u.users).FirstOrDefault(A=>A.Id==id);
                if (appointments != null)
                { 
                    GetAppointmentsWithUsersDto appointmentsDto=new GetAppointmentsWithUsersDto();
                    appointmentsDto.Id = appointments.Id;
                    appointmentsDto.Date = appointments.Date;
                    appointmentsDto.state=appointments.state;
                    foreach(var item in appointments.users)
                    {
                        appointmentsDto.UsersName.Add(item.ToString());
                    }
                    return Ok(appointmentsDto);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult AddAppointments(Appointment appointment)
        {
            if (ModelState.IsValid == true)
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return Ok(appointment);
            }
             return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveAppointments(int id)
        {
            if (ModelState.IsValid==true)
            {
                var appointments=context.Appointments.FirstOrDefault(A=>A.Id==id);
                if (appointments != null)
                {
                    context.Appointments.Remove(appointments);
                    context.SaveChanges();
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpPost("{id:int}")]
        public IActionResult updatAppointments(int id, Appointment NewAppointment)
        {
            if (ModelState.IsValid == true)
            {
                var OldAppointments = context.Appointments.FirstOrDefault(A => A.Id == id);
                if (OldAppointments != null)
                {
                    OldAppointments.Date=NewAppointment.Date;
                    OldAppointments.state=NewAppointment.state;
                    OldAppointments.users=NewAppointment.users;
                    context.SaveChanges();
                    return Ok(OldAppointments);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        //[HttpPut("{id:int}")]
        //public IActionResult AddUserToAppointments(int id)
        //{
        //    var user=context.users.FirstOrDefault(d=>d.Id==id);
        //    if (user != null)
        //    {
        //        context.Appointments.users.Add(user);
        //    }
        //    return BadRequest("not found");
        //}
    }
}
