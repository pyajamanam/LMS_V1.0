using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using LMS.App.Common;
using LMS.App.Core.Data;
using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories;
using LMS.App.Web.Extensions;
using LMS.App.Web.Interfaces;
using LMS.App.Web.Models;
using LMS.App.Web.Services;

namespace LMS.App.Web.Controllers
{
    public class AccountController : Controller
    {
        public IMembershipService MembershipService { get; set; }
        private readonly IUserRepository _userRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly ICountryRepository _countryRepo;

        public AccountController()
        {
            _userRepo = new UserRepository();
            _countryRepo = new CountryRepository();
            _companyRepo = new CompanyRepository();
        }
        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            Log.Info("Login-page started...");
            if (Request.IsAuthenticated)
            {
                Log.Info("User Authenticated ...");
                if (Request.QueryString["ReturnUrl"] != null)
                {
                return Redirect(Request.QueryString["ReturnUrl"]);
                }
            }
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LoginModel model, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    SetupFormsAuthTicket(model.UserName, model.RememberMe);
                    Log.Info("MembershipService.ValidateUser Completed");
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.Clear();
                model.UserName = string.Empty;
                model.Password = string.Empty;
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            ModelState.Clear();
            return RedirectToAction("LogOn", "Account");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            var model = new RegisterModel();
            model.Companies = _companyRepo.GeCompanies().ToSelectListItems(c => c.CompanyName, c => c.CompanyId.ToString());
            model.Countries = _countryRepo.GeCountries().ToSelectListItems(c => c.CountryName, c => c.CountryId.ToString());
            return View("Register",model);
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
             //   MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);
               var user =  AutoMapper.Mapper.Map<User>(model);
                var i = _userRepo.AddUser(user);
                if (i>0)
                {
                    return RedirectToAction("LogOn", "Account");
                }
                ModelState.AddModelError("", "createstatus");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {

            return View();
        }

        // ChangePassword method not implemented in CustomMembershipProvider.cs
        // Feel free to update!

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private User SetupFormsAuthTicket(string userName, bool persistanceFlag)
        {
            User user;
            user = _userRepo.GetUser(userName);
            var userId = user.UserId;
            var userData = userId.ToString(CultureInfo.InvariantCulture);
            var authTicket = new FormsAuthenticationTicket(1, //version
                                                        userName, // user name
                                                        DateTime.Now,             //creation
                                                        DateTime.Now.AddMinutes(30), //Expiration
                                                        persistanceFlag, //Persistent
                                                        userData);

            var encTicket = FormsAuthentication.Encrypt(authTicket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            return user;
        }

        protected override void Dispose(bool disposing)
        {

            _userRepo.Dispose();
            _countryRepo.Dispose();
            _companyRepo.Dispose();
            base.Dispose(disposing);
        }
        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
