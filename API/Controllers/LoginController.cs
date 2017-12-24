using System;
using System.Collections.Generic;
using API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Exceptions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // POST api/login
        [HttpPost]
        public ResponseMessage Post([FromBody]User requestUser)
        {
            AuthenticationService authenticationService = new AuthenticationService();

            try
            {
                User user = authenticationService.Login(requestUser.Username, requestUser.Password);

                ResponseMessage response = new ResponseMessage();
                response.Status = "OK";
                response.Results = user;

                return response;
            } catch (UserNotFoundException) {
                return new ResponseMessage()
                {
                    Status = "ERROR",
                    Message = "User not found"
                };
            }
        }
    }
}
