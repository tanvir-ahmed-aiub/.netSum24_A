using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //fc["Name"] 
            //fc["Email]
            //fc["Gender"]
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(string Name, string Email)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(FormCollection fc) {
        //    //fc["Name"] 
        //    //fc["Email]
        //    //fc["Gender"]
        //    return View();
        //}
    }
}