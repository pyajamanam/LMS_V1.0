using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.App.Core.Data.Entities
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public int UserId { get; set; }
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }
        public Guid? ActivationCode { get; set; }
        public int CountryId { get; set; }

        public int CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual UserDetails UserDetails { get; set; }

        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }

        //public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Qualification> Qualifications { get; set; }

    }


    public class UserDetails
    {
        public int UserDetailsId { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public string EmergencyContactNo { get; set; }
        public string ContactNo { get; set; }
        public string NRIC { get; set; }
        public string Passport { get; set; }
        public virtual User User { get; set; }
    }
}