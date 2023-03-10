using PhanTriVi_2011063105_buoi5.Models;
using PhanTriVi_2011063105_buoi5.ViewModels;
using System;
using System.Collections.Generic;
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
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Category.ToList()
            };
            return View(viewModel);
        }
    }
}