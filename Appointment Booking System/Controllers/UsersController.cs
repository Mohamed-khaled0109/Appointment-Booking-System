using Appointment_Booking_System.DTO;
using Appointment_Booking_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Appointment_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context context;

        public UsersController(Context context)
        {
            this.context = context;
        }

        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        var users = context.users.ToList();
        //        return Ok(users);
        //    }
        //    return BadRequest(ModelState);
        //}

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int id)
        {
            if (ModelState.IsValid == true)
            {
                var user = context.users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    GetUserWithAppointmentDto userDto = new GetUserWithAppointmentDto();
                    userDto.UserName=user.Name;
                    userDto.Email=user.Email;
                    userDto.AppointmentId=user.AppointmentId;
                    userDto.scheduleId = user.scheduleId;
                 //   userDto.AppointmentDate = user.appointment.Date;
                    return Ok(userDto);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        //[HttpGet("{name:alpha}")]
        //public IActionResult GetByName(string name)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        var user = context.users.FirstOrDefault(x => x.Name == name);
        //        if (user != null)
        //        {

        //            GetUserWithAppointmentDto userDto = new GetUserWithAppointmentDto();
        //            userDto.Id = user.Id;
        //            userDto.UserName = user.Name;
        //            userDto.Email = user.Email;
        //            userDto.AppointmentDate = user.appointment.Date;
        //            return Ok(userDto);
        //        }
            
        //        return BadRequest("not found");
        //    }
        //    return BadRequest(ModelState);
        //}

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, Users NewUser)
        {
            if (ModelState.IsValid == true)
            {
                var OldUser = context.users.FirstOrDefault(user => user.Id == id);
                if (OldUser != null)
                {
                    OldUser.Name = NewUser.Name;
                    OldUser.Email = NewUser.Email;
                    OldUser.Password = NewUser.Password;
                    OldUser.ConfirmPassword = NewUser.ConfirmPassword;
                    OldUser.scheduleId = NewUser.scheduleId;
                    OldUser.AppointmentId = NewUser.AppointmentId;
                    context.SaveChanges();
                    return Ok(OldUser);
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteUser(int id)
        {
            if (ModelState.IsValid == true)
            {
                var user=context.users.FirstOrDefault(user=>user.Id == id);
                if (user != null)
                {
                    context.users.Remove(user);
                    context.SaveChanges();
                    return Ok("removed");
                }
                return BadRequest("not found");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            if (ModelState.IsValid == true)
            {
                context.users.Add(user);
                context.SaveChanges();
                return Ok("Added");
            }
            return BadRequest(ModelState);
        }
    }
}
