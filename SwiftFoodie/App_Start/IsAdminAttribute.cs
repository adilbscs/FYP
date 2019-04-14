using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.App_Start
{
    public class IsAdminAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {



            var url = new UrlHelper(filterContext.RequestContext);
            var returnUrl = HttpContext.Current.Request.Url.AbsolutePath;
            var Url = url.Action("login" , "home" , new { returnUrl = returnUrl }).ToString();

            if (HttpContext.Current.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectResult(Url);
                return;
            }
            else
            {
                long UserID = long.Parse(HttpContext.Current.Session["UserID"].ToString());
                DBContextDataBase db = new DBContextDataBase();
               var UserDetails = db.Users.Find(UserID);
                if (UserDetails==null || UserDetails.Role != 1)
                {
                    Url = url.Action("login", "home").ToString();
                    filterContext.Result = new RedirectResult(Url);
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}