using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string ReferenceId { get; set; }
        public string CourseName { get; set; }
        public string Venue { get; set; }
        //public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual Qualification Qualification { get; set; }

    }
}
