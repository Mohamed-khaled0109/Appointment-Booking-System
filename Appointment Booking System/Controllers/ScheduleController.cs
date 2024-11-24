using Appointment_Booking_System.DTO;
using Appointment_Booking_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly Context context;

        public ScheduleController(Context context)
        {
            this.context = context;
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int id)
        {
            if (ModelState.IsValid == true)
            {
               var schedul= context.Schedules.Include(S=>S.users).FirstOrDefault(S=>S.Id == id);
                if (schedul == null)
                {
                    ScheduleWithUsersDto scheduleDto = new ScheduleWithUsersDto();
                    scheduleDto.StartTime = schedul.StartTime;
                    scheduleDto.EndTime = schedul.EndTime;
                    scheduleDto.DayOfWeek = schedul.DayOfWeek;
                    foreach(var item in schedul.users)
                    {
                        scheduleDto.Users.Add(item.ToString());
                    }
                    return Ok(scheduleDto);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id:int}")]
        public IActionResult UpdateSchedule(int id, Schedule NewSchedule)
        {
            if (ModelState.IsValid == true)
            {
                var OldSchedule=context.Schedules.FirstOrDefault(S=>S.Id == id);
                if (OldSchedule!=null)
                {
                    OldSchedule.StartTime=NewSchedule.StartTime;
                    OldSchedule.EndTime=NewSchedule.EndTime;
                    OldSchedule.DayOfWeek = NewSchedule.DayOfWeek;
                    OldSchedule.users= NewSchedule.users;
                    context.SaveChanges();
                    return Ok(OldSchedule);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteSchedule(int id)
        {
            if (ModelState.IsValid == true)
            {
                var OldSchedule = context.Schedules.FirstOrDefault(S => S.Id == id);
                if (OldSchedule != null)
                {
                    context.Schedules.Remove(OldSchedule);
                    context.SaveChanges();
                    return Ok("removed");
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult AddUser(Schedule schedule)
        {
            if (ModelState.IsValid == true)
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();
                return Ok("Added");
            }
            return BadRequest(ModelState);
        }
    }
}
