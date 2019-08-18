using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.App.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult NotFound()
        {
            return View("~/Shared/Error.cshtml");
        }
        public ActionResult PageNotFound()
        {
            return View("~/Shared/404Error.cshtml");
        }

    }
}
