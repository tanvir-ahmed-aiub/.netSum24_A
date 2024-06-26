using PMSDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSDemo.Auth
{
    public class Customer : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User) httpContext.Session["user"];
            if (user != null && user.Type.Equals("Customer")) {
                return true;
            }
            return false;
        }
    }
}