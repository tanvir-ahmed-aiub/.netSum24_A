using IntroEF.DTOs;
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
            var converted = Convert(data);
            return View(converted);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {

            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();
            if (ModelState.IsValid) {
                var st = Convert(s);
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
            
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

            //for delete
            //db.Students.Remove(exobj);
            //db.SaveChanges();
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Search(string Search) {
            DemoDB_A_Sum24Entities db = new DemoDB_A_Sum24Entities();

            var data = (from s in db.Students
                        where s.Email.Contains(Search)
                        select s).ToList();
            //.Single()

            //using same view for multiple puposes

            return View("Index",Convert(data));
        }
        public static StudentDTO Convert(Student s) {
            var name = s.Name.Split(' ');
            return new StudentDTO() { 
                FName = name[0],
                LName = name[1],
                Address = s.Address,
                Email = s.Email,
                Id = s.Id
            };
        }
        public static Student Convert(StudentDTO s)
        {
            return new Student()
            {
                Name = s.FName.Trim() + " "+s.LName.Trim(),
                Address = s.Address,
                Email = s.Email,
                Id = s.Id
            };
        }
        public static List<StudentDTO> Convert(List<Student> students) { 
            var list = new List<StudentDTO>();
            foreach (var s in students) {
                var st = Convert(s);
                list.Add(st);
            }
            return list;
        }
    }
}