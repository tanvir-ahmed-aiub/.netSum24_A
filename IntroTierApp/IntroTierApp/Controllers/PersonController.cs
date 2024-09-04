using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTierApp.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("api/person/all")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data = PersonService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError,new  { Msg="Contact Support",Api= "api/person/all" });
            }
        }
        [HttpGet]
        [Route("api/person/{id}")]
        public HttpResponseMessage Get(int id) {
  
            try
            {
                var data = PersonService.Get(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Student not Found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Contact Support", Api = "api/person/" + id });
            }

        }
        [HttpPost]
        [Route("api/person/create")]
        public HttpResponseMessage Create(PersonDTO p) {
            var data = PersonService.Create(p);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
