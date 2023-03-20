using PhanTriVi_2011063105_buoi5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanTriVi_2011063105_buoi5.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course>UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}