using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.App.Core.Data.Entities
{
   [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  FullName { get; set; }
        public string UserEmailAddress { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? ActivationCode { get; set; }
        public int CompanyId { get; set; }
        public string Designation { get; set; }
        public string Comments { get; set; }
        public int CountryId { get; set; }

        public string EmployeeId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}