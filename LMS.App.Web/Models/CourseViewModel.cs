using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.App.Web.Models
{
    public class CourseViewModel
    {
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        [DisplayName("Course Code")]
        public string CourseCode{ get; set; }
        public string Duration { get; set; }
        public bool Status { get; set; }
        public List<SelectListItem> PreRequsieCourses { get; set; }
        public string Course { get; set; }

    }
}