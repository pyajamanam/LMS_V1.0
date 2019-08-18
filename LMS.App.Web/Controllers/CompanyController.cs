using System.Collections.Generic;
using System.Web.Mvc;
using LMS.App.Core.Data;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories;
using LMS.App.Web.Filters;
using LMS.App.Web.Models;
using Newtonsoft.Json;
using AutoMapper;
namespace LMS.App.Web.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        public readonly ICompanyRepository _companyRepo;

        public CompanyController()
        {
            _companyRepo = new CompanyRepository();
        }
        [ActionName("GetCompany")]
        public ActionResult CompanyIndex()
        {
            return View("Company");
        }

        [HttpGet]
        public ActionResult GetCompanyModel()
        {
            
            return PartialView("_companyAdd",new CompanyViewModel());
        }

        [HttpPost]
        [ActionName("CompanyAdd")]
        public ActionResult Add(CompanyViewModel cvm)
        {
          var company=   Mapper.Map<Company>(cvm);
            var status = _companyRepo.Add(company); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var status = _companyRepo.Delete((int)ID); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getbyID(int CompID)
        {
            var vm =  _companyRepo.Edit((int)CompID);
            return Json(new { companymodel = vm }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            
            var status = _companyRepo.Update(company); 
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompanies()
        {
            var companies = _companyRepo.GeCompanies();
           var list =  AutoMapper.Mapper.Map<List<Company>, List<CompanyViewModel>>(companies);
            JsonConvert.SerializeObject(companies);
            return Json(new { companiesList = companies }, JsonRequestBehavior.AllowGet);

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
