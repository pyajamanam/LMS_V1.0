using LMS.App.Core.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Entities
{
    public class Course : EntityBase
    {
       public Course()
        {
            CourseName =  this.CourseName+ '('+ this.CourseCode +')'; 
        }

        public int CourseId { get; set; }
        //public string ReferenceId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode{ get; set; }
        public string Duration{ get; set; }
        public bool Status{ get; set; }
        public bool IsDeleted { get; set; }
        public int? PreRequsiteCourseId { get; set; }
        public virtual Course CourseParent { get; set; }

        public virtual ICollection<Qualification> Qualifications { get; set; }

    }

    public class CoursePrerequsite
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public virtual Course CourseParent { get; set; }
    }
}
