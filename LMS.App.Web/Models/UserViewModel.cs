using System.Collections.Generic;
using System.Web.Mvc;

namespace LMS.App.Web.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Rolelist = new List<SelectListItem>();
            CountryList = new List<SelectListItem>();
            CompanyList = new List<SelectListItem>();
        }
        public List<SelectListItem> Rolelist { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Inactive { get; set; }
        public string Role { get; set; }
    }

    public class RoleViewModel
        {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

}