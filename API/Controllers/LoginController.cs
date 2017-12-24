using System;
using System.Collections.Generic;
using API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // POST api/login
        [HttpPost]
        public User Post([FromBody]User requestUser)
        {
            User ployUser = new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
            return ployUser;
        }
    }
}
