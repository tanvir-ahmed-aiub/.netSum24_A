using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();
            var exobj = db.Students.Find(id);
            return View(exobj);

        }
        [HttpPost]
        public ActionResult Edit(Student s) {
            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();
            var exobj = db.Students.Find(s.Id);
            exobj.Address = s.Address;
            exobj.Name = s.Name;
            exobj.Phone = s.Phone;
            exobj.Email = s.Email;

            //caution in using this method
            //db.Entry(exobj).CurrentValues.SetValues(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}