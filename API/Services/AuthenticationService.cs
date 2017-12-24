using System;
using API.Models;

namespace API.Services
{
    public class AuthenticationService
    {
        public User Login(string username, string password)
        {
            return new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
        }
    }
}
