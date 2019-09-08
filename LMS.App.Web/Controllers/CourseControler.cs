using System.Collections.Generic;
using System.Web.Mvc;
using LMS.App.Core.Data;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories.Abstractions;
using LMS.App.Web.Filters;
using LMS.App.Web.Models;
using Newtonsoft.Json;
using AutoMapper;
using LMS.App.Core.Data.Repositories;

namespace LMS.App.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        public readonly ICourseRepository _CourseRepo;

        public CourseController()
        {
            _CourseRepo = new CourseRepository();
        }
        [ActionName("GetCourse")]
        public ActionResult CourseIndex()
        {
            return View("Course");
        }

        [HttpGet]
        public ActionResult GetCourseModel()
        {
            
            return PartialView("_CourseAdd",new CourseViewModel());
        }

        [HttpPost]
        [ActionName("CourseAdd")]
        public ActionResult Add(CourseViewModel cvm)
        {
          var Course=   Mapper.Map<Course>(cvm);
            var status = _CourseRepo.CreateCourse(Course); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var status = _CourseRepo.DeleteCourse((int)ID); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getbyID(int CompID)
        {
            var vm =  _CourseRepo.EditCourse((int)CompID);
            return Json(new { Coursemodel = vm }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Course Course)
        {
            
            var status = _CourseRepo.UpdateCourse(Course); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public ActionResult Protected()
        {
            var user = (UserIdentity)User.Identity;
            return View((object)user.UserId);
        }

        [Authorize(Roles = "WebshopBackEnd")]
        public ActionResult SuperAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize]
        public ActionResult AdminOrSuperAdmin()
        {
            if (!User.IsInRole("WebshopBackEnd") && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [Authorize(Roles = "Admin,Agent,Delear, Author")]
        public ActionResult AdminOrAuthor()
        {
            return View();
        }

        [Authorize(Users = "karthik,testuser")]
        public ActionResult SelectedUsersOnly()
        {
            return View();
        }
    }
}
