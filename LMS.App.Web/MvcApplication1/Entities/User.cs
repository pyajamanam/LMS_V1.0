using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.App.Web.Entities
{
   [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}