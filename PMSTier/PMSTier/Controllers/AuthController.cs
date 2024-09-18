using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMSTier.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var token = AuthService.Authenticate(login.Uname, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var key = Request.Headers.Authorization;
            if (key == null) return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
            try
            {
                
                var token = AuthService.LogoutToken(key.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, token);
               

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
            }
        }

    }
}
