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
            var data = PersonService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [HttpGet]
        [Route("api/person/{id}")]
        public HttpResponseMessage Get(int id) {
            var data = PersonService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
