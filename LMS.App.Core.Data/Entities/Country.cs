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
    [Table("Countries")]
    public class Country: EntityBase
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
