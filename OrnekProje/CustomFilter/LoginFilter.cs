using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekProje.CustomFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var SessionControl = context.HttpContext.Session["Kullanici"];
            if (SessionControl == null)
            {
                context.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary { { "controller", "User" }, { "action", "Login" } });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
          
        }
    }
}