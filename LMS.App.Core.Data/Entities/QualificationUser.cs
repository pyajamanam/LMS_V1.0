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
    public class QualificationUser : EntityBase
    {
        public QualificationUser()
        {
        }
        [Key]
        public int Id { get; set; }
       [ForeignKey("Qualification")]
        public int UserQualificationId { get; set; }
       [ForeignKey("User")]
        public  int UserId { get; set; }
        public virtual User Course { get; set; }
        public virtual Qualification Qualification { get; set; }
        //public virtual User User { get; set; }



    }
}
