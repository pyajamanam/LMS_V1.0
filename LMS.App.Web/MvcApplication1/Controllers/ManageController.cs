using LMS.App.Core.Data.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LMS.App.Core.Data.Repositories;

namespace LMS.App.Web.Controllers
{
    public class ManageController : Controller
    {
        public readonly UserRepository _usersContext;

        public ManageController()
        {
            _usersContext = new UserRepository();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public JsonResult UpdateRole(int userId, short roleId)
        {
           // _usersContext.AddUserRole(new UserRole{ UserId = userId, RoleId = roleId});
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

    public static class ListProvider
    {
        public static List<SelectListItem> Roles = new List<SelectListItem>
                                                   {
                                                       new SelectListItem { Text = "WebshopBackEnd", Value = "0" },
                                                       new SelectListItem { Text = "Delear", Value = "1" },
                                                       new SelectListItem { Text = "Agent", Value = "2" }
                                                   };

        public static List<SelectListItem> GetRoles(short roleId)
        {
            Roles.ForEach(r => r.Selected = false);
            var role = Roles.Single(r => r.Value == roleId.ToString(CultureInfo.InvariantCulture));
            role.Selected = true;
            return Roles;
        }
    }
}
