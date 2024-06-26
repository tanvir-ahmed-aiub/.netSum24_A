using PMSDemo.DTOs;
using PMSDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSDemo.Controllers
{
    public class LoginController : Controller
    {
        PMS_Sm24_AEntities db = new PMS_Sm24_AEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l) {
            if (ModelState.IsValid) {
                var user = (from u in db.Users
                         where u.Uname.Equals(l.Uname) &&
                         u.Pass.Equals(l.Password)
                         select u).SingleOrDefault();
                if (user == null) {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull";
                if (user.Type.Equals("Admin")) {
                    return RedirectToAction("Index","Admin");
                }
                return RedirectToAction("Index","Order");
            }
            return View(l);
        }
    }
}