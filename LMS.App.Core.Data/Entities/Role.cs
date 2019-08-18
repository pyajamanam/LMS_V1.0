using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.App.Core.Data.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public short RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
       public virtual ICollection<User> Users { get; set; }
    }
}