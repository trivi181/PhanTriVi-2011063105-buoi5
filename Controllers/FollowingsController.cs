using Microsoft.AspNet.Identity;
using PhanTriVi_2011063105_buoi5.DTOs;
using PhanTriVi_2011063105_buoi5.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace PhanTriVi_2011063105_buoi5.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Follwing already exits!");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}