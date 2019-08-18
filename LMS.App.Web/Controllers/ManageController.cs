using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LMS.App.Common.Helpers;
using LMS.App.Core.Data;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories;
using LMS.App.Web.Filters;
using LMS.App.Web.Models;

namespace LMS.App.Web.Controllers
{

    public class ManageController : Controller
    {
        public readonly IUserRepository _usersRepo;
        public readonly IRoleRepository _roleRepo;

        public ManageController()
        {
            _roleRepo = new RoleRepository();
            _usersRepo = new UserRepository();
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var vm = _usersRepo.GetUsers().Select(b => new UserViewModel
            {
                UserId = b.UserId,
                UserName = b.UserName,
                EmailAddress = b.UserEmailAddress,
                Role = b.Roles.Select(x => x.RoleName).FirstOrDefault()// etc

            }).ToList();
            return View("Users", vm);
        }



        public JsonResult GetbyID(int ID)
        {
            var rolesUser = _roleRepo.GetRolesbyUserId(ID);
            var vm = _usersRepo.GetUserById(ID);
            //vm.Rolelist = ListProvider.GetRoles(roles.RoleId);
            var viewmodel = new UserViewModel()
            {
                UserName = vm.UserName,FullName = vm.FullName,
                EmailAddress = vm.UserEmailAddress,
                UserId = vm.UserId,
                Inactive = vm.IsDeleted,
                Role = rolesUser!=null?rolesUser.RoleName:"N/A",
                Rolelist = rolesUser!=null ? ListProvider.GetRoles(rolesUser.RoleId) : ListProvider.Roles
            };
            return Json(new { usermodel = viewmodel }, JsonRequestBehavior.AllowGet);
            // return null;
        }


        [HttpPost]
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Roles()
        {
            //var roles = _usersRepo.Roles.Select(p => new RoleViewModel
            //{
            //    RoleId = p.RoleId,
            //    RoleName = p.RoleName,
            //    Description = p.RoleDescription
            //});

            return View("Roles", ListProvider.Roles);
        }
        [CustomAuthorize(Roles = "Admin")]
        // [HttpPost]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var roles = _LMSContext.UserRoles.Where(x => x.UserId == id).Select(r => r.Role).FirstOrDefault();
            //var vm = _LMSContext.Users.Where(x => x.UserId == id).Select(P => new UserViewModel()
            //{
            //    UserName = P.UserName,
            //    EmailAddress = P.UserEmailAddress,
            //    UserId = P.UserId,
            //    Role = roles.RoleName

            //}).FirstOrDefault();
            //vm.Rolelist = ListProvider.GetRoles(roles.RoleId);
            //return View("Edit", vm);
            return null;
        }



        [CustomAuthorize(Roles = "Admin")]
        // [HttpPost]
        [HttpGet]

        [HttpPost]
        public ActionResult UpdateUser(User user, short roleid)
        {
            //var dbuser = _LMSContext.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            //if (user != null)
            //{
            //    dbuser.UserName = user.UserName;
            //    dbuser.UserEmailAddress = user.UserEmailAddress;
            //    _LMSContext.AddUserRole(new UserRole { UserId = dbuser.UserId, RoleId = roleid });

            //}
            // _LMSContext.Update(user);
            //int res = _LMSContext.SaveChanges();
            int res = 0;
            if (res != 0)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel vm)
        {
            var user = new User()
            {
                // UserId = vm.UserId,
                UserEmailAddress = vm.EmailAddress,
                UserName = vm.UserName, IsDeleted = true,FullName =vm.FullName,
                Password = PasswordHelper.GetMd5Hash(vm.Password)

            };
            var userRole = new UserRole()
            {
                UserId = vm.UserId,
                RoleId = Convert.ToInt16(vm.Role)
            };

            return Json(new { success = _usersRepo.AddUser(user) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModel vm)
        {
            var user = new User()
            {
                UserId = vm.UserId,
                UserEmailAddress = vm.EmailAddress,
                UserName = vm.UserName,ActivationCode = Guid.NewGuid(),FullName = vm.FullName,
                Password= PasswordHelper.GetMd5Hash(vm.Password),IsDeleted = vm.Inactive

            };
            var userRole = new UserRole()
            {
                UserId = vm.UserId,
                RoleId = Convert.ToInt16(vm.Role)
            };

            return Json(new { success = _usersRepo.UpdateUser(user, userRole) > 0 ? true : false }, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Admin")]
        public JsonResult UserList()
        {
            var vm = _usersRepo.GetUsers().Where(x=>!x.IsDeleted).Select(b => new UserViewModel
            {
                UserId = b.UserId,
                UserName = b.UserName,
                FullName = b.FullName,
                Inactive = b.IsDeleted,
                EmailAddress = b.UserEmailAddress,
                Role = b.Roles.Select(x => x.RoleName).FirstOrDefault()// etc

            }).ToList();
            return Json(new { UserModel = vm }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult InactiveUserList()
        {
            var vm = _usersRepo.GetUsers().Where(x => x.IsDeleted).Select(b => new UserViewModel
            {
                UserId = b.UserId,
                UserName = b.UserName,
                FullName =b.FullName,
                EmailAddress = b.UserEmailAddress,
                Inactive =b.IsDeleted,
                Role = b.Roles.Select(x => x.RoleName).FirstOrDefault()// etc

            }).ToList();
            return Json(new { UserModel = vm }, JsonRequestBehavior.AllowGet);
        }



        //[Authorize(Roles = "Admin")]
        //public JsonResult UpdateRole(int userId, short roleId)
        //{
        //    _LMSContext.AddUserRole(new UserRole { UserId = userId, RoleId = roleId });
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}
    }

    public static class ListProvider
    {
        public static List<SelectListItem> Roles = new List<SelectListItem>
                                                   {
                                                       new SelectListItem { Text = "Admin", Value = "1" },
                                                       new SelectListItem { Text = "User", Value = "2" },
                                                       new SelectListItem { Text = "Trainee", Value = "3" }
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
