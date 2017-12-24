using System;
using API.Exceptions;
using API.Models;
using API.Services;

namespace API.UnitTests
{
    public class StubSuccessAuthenticationService : IAuthenticationService
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
