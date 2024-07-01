using PostCommentDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostCommentDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Request["ReturnUrl"] != null) {
                ViewBag.URL = Request["ReturnUrl"];
            }
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l,string URL) {
            if (ModelState.IsValid) {
                if (l.Uname.Equals("admin") && l.Password.Equals("admin")) {
                    Session["user"] = l;
                    if(URL != null && !URL.Equals(""))
                        return Redirect(URL);
                    else
                        return RedirectToAction("Index","Dashboard");

                }
            }
            return View(l);
        }
    }
}