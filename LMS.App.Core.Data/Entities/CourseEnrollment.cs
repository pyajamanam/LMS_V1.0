using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Entities
{
    public class CourseEnrollment
    {
        public CourseEnrollment()
        {
        }
        [Key]
        public int EnrolmentId { get; set; }
        public  int UserId { get; set; }
       [ForeignKey("Course")]
        public  int CourseId { get; set; }
        //public string CourseName { get; set; }
        //public string CourseDate { get; set; }
        //public string Venue { get; set; }
        //[ForeignKey("User")]
        public int TrainerId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
