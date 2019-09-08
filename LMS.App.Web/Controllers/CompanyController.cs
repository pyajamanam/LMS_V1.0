﻿using System.Collections.Generic;
using System.Web.Mvc;
using LMS.App.Core.Data;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories;
using LMS.App.Web.Filters;
using LMS.App.Web.Models;
using Newtonsoft.Json;
using AutoMapper;
using System.Linq;

namespace LMS.App.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        public readonly UnitOfWork uow;

        public CompanyController()
        {
             uow = new UnitOfWork();
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
          var compnay = uow.CompanyRepository.Insert(company); uow.Save();
            return Json(new { result = compnay!=null ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            uow.CompanyRepository.Delete(id);
           var i= uow.Save();
            var status= i>0; 
            return Json(new { result = status}, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getbyID(int CompID)
        {
            var vm = uow.CompanyRepository.GetByID(CompID);
            return Json(new { companymodel = vm }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            uow.CompanyRepository.Update(company);
            uow.Save();
            var status= uow.Save()>0;
            return Json(new { result = status ? "true" : "false" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompanies()
        {
           var companies =  uow.CompanyRepository.Get();
           var list =  AutoMapper.Mapper.Map<List<Company>, List<CompanyViewModel>>(companies.ToList());
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
