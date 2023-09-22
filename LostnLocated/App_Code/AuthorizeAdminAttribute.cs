using System;
//using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LostnLocated.Models;

namespace LostnLocated.App_Code
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool IsValidUser;
            if (httpContext.Session["AdminId"] == null)
                IsValidUser = false;
            else
                IsValidUser = true;
            return IsValidUser;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "General" }));
        }
    }


}