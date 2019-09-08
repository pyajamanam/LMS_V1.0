using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace LMS.App.Infrastructure
{
    public class CustomMembershipUser : MembershipUser
    {
      public CustomMembershipUser()
        {
            Roles = new List<Role>();
        }
        #region User Properties  
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Role> Roles { get; set; }

        #endregion

        public CustomMembershipUser(User user) : base("CustomMembership", user.UserName, user.UserId, user.UserEmailAddress, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.UserId;
            CountryId = user.CountryId;
            CompanyId = user.CompanyId;
           Roles = user.Roles;
        }
    }
}
