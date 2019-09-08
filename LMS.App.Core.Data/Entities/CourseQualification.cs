using LMS.App.Core.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Entities
{
    public class CourseQualification : EntityBase
    {
        public CourseQualification()
        {
        }
        public int Id { get; set; }
        public int QualificationId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Qualification Qualification { get; set; }
        //public virtual User User { get; set; }

    }
}
