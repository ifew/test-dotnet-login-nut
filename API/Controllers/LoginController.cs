using System;
using System.Collections.Generic;
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
        public System.Dynamic.ExpandoObject Post([FromBody]string value)
        {
            dynamic ployUser = new System.Dynamic.ExpandoObject();
            ployUser.id = 1;
            ployUser.username = "ploy";
            ployUser.displayname = "พลอย";
            return ployUser;
        }
    }
}
