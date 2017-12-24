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
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService service)
        {
            authenticationService = service;
        }

        // POST api/login
        [HttpPost]
        public ResponseMessage Post([FromBody]User requestUser)
        {
            try
            {
                User user = authenticationService.Login(requestUser.Username, requestUser.Password);
                return new ResponseMessage(){
                    Status = "OK",
                    Results = user
                };
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
