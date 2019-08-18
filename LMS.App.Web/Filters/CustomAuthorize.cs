using LMS.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LMS.App.Web.Filters
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                Log.Info("User Authedication failed ..."+this.GetType());
                filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Account", action = "LogOn" }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "AccessDenied",action = "Denied" }));
            }
        }
    }
}