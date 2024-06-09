using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //db  to data
            ViewBag.Name = "Adv .Net";
            ViewBag.CTeacher = "Tanvir";

            Student s1 = new Student() { 
                Name = "Rahim",
                Id = 1,
                Cgpa = 2.45f
            };
            Student s2 = new Student()
            {
                Name = "Karim",
                Id = 2,
                Cgpa = 2.85f
            };
            Student s3 = new Student()
            {
                Name = "Rahman",
                Id = 3,
                Cgpa = 2.95f
            };


            ViewBag.Students = new Student[] { s1, s2, s3 };
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(string id) {
            ViewBag.StName = id;
            return View();
        }
    }
}