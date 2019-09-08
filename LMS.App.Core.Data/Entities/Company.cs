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
    [Table("Companies")]
    public class Company: EntityBase
    {
        [Key]
        public int CompanyId { get; set; }
        public string  CompanyName { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }

    }
}
