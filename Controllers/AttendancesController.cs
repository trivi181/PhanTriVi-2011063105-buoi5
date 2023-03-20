using Microsoft.AspNet.Identity;
using PhanTriVi_2011063105_buoi5.DTOs;
using PhanTriVi_2011063105_buoi5.Models;
using System.Linq;
using System.Web.Http;

namespace PhanTriVi_2011063105_buoi5.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if(_dbContext.Attendances.Any(a=>a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                    return BadRequest("The Attendance already exits!");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId= userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }   
}
