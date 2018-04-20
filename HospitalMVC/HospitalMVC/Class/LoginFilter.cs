using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMVC.Class
{
    public class LoginFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var ID = filterContext.HttpContext.Request.Cookies["ID"];
            var fName = filterContext.HttpContext.Request.Cookies["fName"];
            var lName = filterContext.HttpContext.Request.Cookies["lName"];
            
            if(ID == null || fName == null || lName == null)
            {
                filterContext.Result = new HttpUnauthorizedResult("Not logged in please login to navigate the website");
            }
        }
    }
}