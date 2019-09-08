using LMS.App.Core.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Entities
{
    public class CourseSchedule: EntityBase
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode{ get; set; }
        public string Duration{ get; set; }
        public string Venue { get; set; }
        public string Remarks { get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate { get; set; }
        public bool Status{ get; set; }
        public int TrainerId{ get; set; }
        public int UserId { get; set; }

        public int QualificationId { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public virtual Qualification Qualification { get; set; }


    }
}
