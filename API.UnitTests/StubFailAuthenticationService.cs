using System;
using API.Exceptions;
using API.Models;
using API.Services;

namespace API.UnitTests
{
    public class StubFailAuthenticationService : IAuthenticationService
    {
        public User Login(string username, string password)
        {
            throw new UserNotFoundException("Wrong username or password");
        }
    }
}
