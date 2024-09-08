using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTierApp.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [Route("api/department/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DepartmentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Contact Support", Api = "api/department/all" });
            }
        }
    }
}
