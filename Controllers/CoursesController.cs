using Microsoft.AspNet.Identity;
using PhanTriVi_2011063105_buoi5.Models;
using PhanTriVi_2011063105_buoi5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanTriVi_2011063105_buoi5.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel 
            { 
                Categories = _dbContext.Category.ToList()
            };
            return View(viewModel);

        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Category.ToList();
                return View("Create",viewModel);
            }
            var course = new Course
            {
                LectuerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Course.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lectuer)
                .Include(l => l.Category)
                .ToList();
            var viewModel = new CoursesViewModel
            { 
                UpcommingCourses = courses ,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

    }
}