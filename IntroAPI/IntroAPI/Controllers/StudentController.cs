using IntroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/student/all")]
        public HttpResponseMessage AllStudents() { 
            //db object
            //var data = db.Students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK,"data");
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage SingleStudent(int id) {
            //db object
            //var data = db.Students.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, "data");
        }
        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage CreateStudent(Student s) {
            //db object
            //db.Students.Add(s);
            //db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Created");

        }
    }
}
