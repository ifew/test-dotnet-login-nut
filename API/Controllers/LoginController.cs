using System;
using System.Collections.Generic;
using API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // POST api/login
        [HttpPost]
        public User Post([FromBody]User requestUser)
        {
            AuthenticationService authenticationService = new AuthenticationService();
            return authenticationService.Login(requestUser.Username, requestUser.Password);
        }
    }
}
