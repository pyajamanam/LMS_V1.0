using LMS.App.Common.Enums;
using LMS.App.Common.Helpers;
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
    public class Qualification: EntityBase
    {
        public Qualification()
        {
        }
        public int Id { get; set; }
        [Key] public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationCode { get; set; }
        public string Remarks { get; set; }

        public int ColorId { get; set; }
        public int FontColorCardId { get; set; }

        //[ForeignKey("Course")]

        public virtual ICollection<ColorCode> Colorcodes { get; set; }
        public virtual ICollection<FontColors> FontColors  { get;set; }

        //public virtual CourseQualification CourseQualification { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        //EnumHelper.GetEnumValues<FontColors>().ToList();
        //= EnumHelper.GetEnumValues<ColorCode>().ToList();
        public virtual ICollection<User> Users { get; set; }

    }
}
