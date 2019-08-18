using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.App.Web.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public short RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}